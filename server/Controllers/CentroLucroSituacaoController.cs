using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsList;
using server.ModelsQuery;
using server.Shared.ComboBox;
using server.Shared.DataGrid;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroLucroSituacaoController : CrudController<CentroLucroSituacao , CentroSituacaoQuery>
{
      private readonly IMapper _mapper;
      public CentroLucroSituacaoController(IMapper mapper)
      {
            _mapper = mapper;
      }
      
      [HttpGet("Filtrar")]
      public override ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroSituacaoQuery query)
      {
            var filter = context.CentroLucroSituacao!
                  .Include(x => x.Exercicio )
                  .Include(x => x.CentroLucro)
                  .Include(x => x.CentroLucroUsuario)
                  .Select(x => _mapper.Map<CentroSituacaoList>(x))
                  .AsNoTrackingWithIdentityResolution()
                  .AsQueryable()
                  .Filter(query).Sort(query);
            // new CentroSituacaoList { Id = x.Id, Exercicio = x.Exercicio!.Ano, Centro = x.CentroLucro!.Nome}
            
            var dataGrid = new DataGrid(filter.CountAsync().Result , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent( filter.ToListAsync().Result);
            
            return Ok(dataGrid);
      }


      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroLucroSituacao!
                  .Include(x => x.CentroLucroUsuario)
                  .FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroLucros = context.CentroLucro!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList();
            model.CentroStatus = context.CentroStatus!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList();
            model.CentroLucroUsuarios = context.CentroLucroUsuario!.Where(x => x.IdCentroLucro == model.IdCentroLucro).Select(x => new ComboBox { Id = x.Id, Descricao = x.Email! }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroLucroSituacao
            {
                  CentroLucros = context.CentroLucro!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Exercicios = context.Exercicio!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Ano }).AsNoTrackingWithIdentityResolution().ToList(),
                  CentroStatus = context.CentroStatus!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome! }).AsNoTrackingWithIdentityResolution().ToList(),
                  CentroLucroUsuarios = context.CentroLucroUsuario!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Email! }).AsNoTrackingWithIdentityResolution().ToList(),
            };

            return  Ok(model);
      }
}