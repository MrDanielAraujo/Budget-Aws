using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFramework.Exceptions.Common;
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
public class CentroCustoSituacaoController : CrudController<CentroCustoSituacao, CentroSituacaoQuery>
{
      private readonly IMapper _mapper;

      public CentroCustoSituacaoController(IMapper mapper)
      {
            _mapper = mapper;
      }

      [HttpGet("Filtrar")]
      public override ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroSituacaoQuery query)
      {
            var filter = context.CentroCustoSituacao!
                  .Include(x => x.Exercicio)
                  .Include(x => x.CentroCusto)
                  .Include(x => x.CentroCustoUsuario)
                  .ProjectTo<CentroSituacaoList>(_mapper.ConfigurationProvider)
                  .AsNoTrackingWithIdentityResolution()
                  .AsQueryable()
                  .Filter(query).Sort(query);

            var dataGrid = new DataGrid(filter.CountAsync().Result, query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);

            dataGrid.DataContent(filter.ToListAsync().Result);

            return Ok(dataGrid);
      }


      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroCustoSituacao!
                  .Include(x => x.CentroCustoUsuario)
                  .Include(x => x.CentroCusto)
                  .FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            model.Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList();
            model.LancamentoTipos = context.LancamentoTipo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.CentroStatus = context.CentroStatus!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            model.CentroCustoUsuarios = context.CentroCustoUsuario!.Where(x => x.IdCentroCusto == model.IdCentroCusto).Select(x => new ComboBox { Id = x.Id, Descricao = x.Email! }).AsNoTrackingWithIdentityResolution().ToList();

            return Ok(model);
      }

      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroCustoSituacao
            {
                  CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList(),
                  Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList(),
                  LancamentoTipos = context.LancamentoTipo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  CentroStatus = context.CentroStatus!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList(),
            };

            return Ok(model);
      }

      [HttpPut("ResetAll")]
      public ActionResult<dynamic> ResetAll([FromServices] Context context)
      {
            
            var centroStatus = context.CentroStatus!.FirstOrDefault(x => x.Codigo == 1);
            
            if(centroStatus == null) return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            
            var centroCustoUsuarios = context.CentroCustoUsuario!.Where(x =>  x.Nivel == 0).ToList();
            
            if(!centroCustoUsuarios.Any()) return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            
            var centroCustoSituacaoList = context.CentroCustoSituacao!.Include(x => x.Exercicio).Where(x => x.Exercicio!.Aberto).ToList();
            
            if(!centroCustoSituacaoList.Any()) return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            
            foreach (var centroCustoSituacao in centroCustoSituacaoList)
            {
                  centroCustoSituacao.IdCentroStatus = centroStatus!.Id;
                  centroCustoSituacao.IdCentroCustoUsuario = centroCustoUsuarios.FirstOrDefault(x => x.IdCentroCusto == centroCustoSituacao.IdCentroCusto)!.Id;
            }

            try
            {
                  context.CentroCustoSituacao!.AttachRange(centroCustoSituacaoList);
                  context.SaveChanges();
            }
            catch (UniqueConstraintException)
            {
                  return BadRequest(new ValidationResultModel([new ValidationError("", "uniquekey")]));
            }
            catch (Exception)
            {
                  return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            }

            return Ok();
      }
      
      [HttpPut("Reset")]
      public ActionResult<dynamic> Reset([FromServices] Context context,  [FromBody] CentroCustoSituacao model)
      {
            var centroStatus = context.CentroStatus!.FirstOrDefault(x => x.Codigo == 1);
            
                  if(centroStatus == null) return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            
            var centroCustoUsuario = context.CentroCustoUsuario!.FirstOrDefault(x =>  x.Nivel == 0 && x.IdCentroCusto == model.IdCentroCusto);
            
                  if(centroCustoUsuario == null) return BadRequest(new ValidationResultModel([new ValidationError("", "fail")]));
            
                  
            model.IdCentroStatus = centroStatus!.Id;
            model.IdCentroCustoUsuario = centroCustoUsuario!.Id;
            
            var (success, typError) = context.SaveUpdate(model);
            
            return (success)? Ok(): BadRequest(new ValidationResultModel([new ValidationError("", typError)]));
      }
}