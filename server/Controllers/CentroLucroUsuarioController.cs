using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;
using server.Shared.DataGrid;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroLucroUsuarioController : CrudController<CentroLucroUsuario , CentroLucroUsuarioQuery>
{
      [HttpGet("Filtrar")]
      public override ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroLucroUsuarioQuery query)
      {
            var filter = context.CentroLucroUsuario!
                  .Include(x => x.CentroLucro )
                  .Select(x => new { Id = x.Id, Email = x.Email, Centro = x.CentroLucro!.Nome})
                  .AsNoTrackingWithIdentityResolution()
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
            var model = context.CentroLucroUsuario!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroLucros = context.CentroLucro!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context )
      {
            var model = new CentroLucroUsuario
            {
                  CentroLucros = context.CentroLucro!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
}