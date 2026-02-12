using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsList;
using server.ModelsQuery;
using server.Shared.ComboBox;
using server.Shared.Crudl;
using server.Shared.DataGrid;
using server.Shared.ValidationError;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroCustoUsuarioController(IMapper mapper) : CrudController<CentroCustoUsuario, CentroCustoUsuarioQuery>
{
      [HttpGet("Filtrar")]
      public override ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroCustoUsuarioQuery query)
      {
            var filter = context.CentroCustoUsuario!
                  .Include(x => x.CentroCusto )
                  .ProjectTo<CentroUsuarioList>(mapper.ConfigurationProvider)
                  .AsQueryable()
                  .Filter(query).Sort(query);
            
            var dataGrid = new DataGrid(filter.CountAsync().Result , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent( filter.ToListAsync().Result);
            
            return Ok(dataGrid);
      }
      
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroCustoUsuario!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroCustoUsuario
            {
                  CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
      
      public override ActionResult<dynamic> Create([FromServices] Context context, [FromBody] CentroCustoUsuario model)
      {
            if( !ModelState.IsValid ) return BadRequest(NotValidMsg);

            using var transaction = context.Database.BeginTransaction();
            try
            {
                  var (success,  typeError) = context.SaveCreate(model);

                  if(!success) throw new Exception(typeError);
                  
                  var centroCusto = context.CentroCusto!.AsNoTrackingWithIdentityResolution().FirstOrDefault(x => x.Id == model.IdCentroCusto);

                  centroCusto!.NivelTotal = context.CentroCustoUsuario!.Count(x => x.IdCentroCusto == model.IdCentroCusto);

                  var (updateSuccess, updateTypeError) = context.SaveUpdate(centroCusto);
                        
                  if(!updateSuccess) throw new Exception(updateTypeError);
                  
                  transaction.Commit();
                  
            }
            catch (Exception e)
            {
                 transaction.Rollback();
                 
                 return BadRequest(new ValidationResultModel([new ValidationError("", e.Message)]));
            }

            return Ok();
            
      } 
      
      public override ActionResult<dynamic> Update([FromServices] Context context, [FromBody] CentroCustoUsuario model)
      {
            if (!ModelState.IsValid) return BadRequest(NotValidMsg);
            
            using var transaction = context.Database.BeginTransaction();
            try
            {
                  var (success,  typeError) = context.SaveUpdate(model);

                  if(!success) throw new Exception(typeError);
                  
                  var centroCusto = context.CentroCusto!.AsNoTrackingWithIdentityResolution().FirstOrDefault(x => x.Id == model.IdCentroCusto);

                  centroCusto!.NivelTotal = context.CentroCustoUsuario!.Count(x => x.IdCentroCusto == model.IdCentroCusto);

                  var (updateSuccess, updateTypeError) = context.SaveUpdate(centroCusto);
                        
                  if(!updateSuccess) throw new Exception(updateTypeError);
                  
                  transaction.Commit();
                  
            }
            catch (Exception e)
            {
                  transaction.Rollback();
                 
                  return BadRequest(new ValidationResultModel([new ValidationError("", e.Message)]));
            }

            return Ok();
      } 
      
}