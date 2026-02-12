using System.Linq.Dynamic.Core;
using server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;
using server.ModelsList;
using server.Shared.DataGrid;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroFilialController : CrudController<CentroFilial, CentroFilialQuery>
{
      private readonly IMapper _mapper;
      public CentroFilialController(IMapper mapper)
      {
            _mapper = mapper;
      }
      
      [HttpGet("Filtrar")]
      public override ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroFilialQuery query)
      {
            var filter = context.CentroFilial!
            .Include(x => x.Empresa)
            .ProjectTo<CentroFilialList>(_mapper.ConfigurationProvider)
            .AsNoTrackingWithIdentityResolution()
            .AsQueryable()
            .Filter(query)
            .Sort(query);
            
            var dataGrid = new DataGrid(filter.CountAsync().Result, query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);

            dataGrid.DataContent(filter.ToListAsync().Result.Select(x => _mapper.Map<CentroFilialList>(x)));

            return Ok(dataGrid);
      }

      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroFilial!.Include(x => x.Empresa).FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound(NotFoundMsg);

            model.Empresas = context.CentroEmpresa!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();

            return Ok(model);
      }

      [HttpGet("filter")]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroFilial
            {
                  Empresa = new CentroEmpresa(),
                  Empresas = context.CentroEmpresa!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return Ok(model);
      }
}