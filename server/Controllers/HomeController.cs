using System.Linq.Dynamic.Core;
using System.Text;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Sort;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.DataGrid;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController(IMapper mapper) : ControllerBase
{
      [HttpGet("Filtrar")]
      public ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] CentroSituacaoHomeQuery query)
      {
            if (string.Equals(query.CentroTipo, "centroCusto", StringComparison.InvariantCultureIgnoreCase)) return Ok(CentroCusto(context, query));
            if (string.Equals(query.CentroTipo, "centroLucro", StringComparison.InvariantCultureIgnoreCase)) return Ok(CentroLucro(context, query));

            return BadRequest();
      }

      private DataGrid CentroCusto(Context context, CentroSituacaoHomeQuery query )
      {
            var filter = context.CentroCustoSituacao!
                  .Include(x => x.Exercicio)
                  .Include(x => x.CentroStatu)
                  .Include(x => x.CentroCustoUsuario)
                  .Include(x => x.CentroCusto)
                  .Where(x => x.Exercicio!.Aberto)
                  .ProjectTo<HomeCentroCusto>(mapper.ConfigurationProvider)
                  .AsQueryable()
                  .Filter(query)
                  .Sort(query);
            
            var dataGrid = new DataGrid( filter.Count() , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent( filter.ToList());

            return dataGrid;
      }
      
      private static DataGrid CentroLucro(Context context, CentroSituacaoHomeQuery query )
      {
            /*
            //var lista = context.HomeCentroLucro!.FromSqlRaw("dbo_budget.HomeCentroLucro").ToList();
            var lista = context.HomeCentroLucro!.ToList();
            //Todo Esse codigo deve ser utilizado quando estiver obtendo o usuário e verificando o perfil.
            //var lista = context.HomeCentroLucro.FromSqlRaw("HomeCentroLucroUsuario {0}", "daniel.gomes@icl-group.com").ToList();
            
            var filter = lista.AsQueryable().Filter(query).Sort(query);
            
            var dataGrid = new DataGrid( filter.Count() , query.Pagination, query.PageNow, query.PageSize);

            if (query.Pagination) filter = filter.Skip(dataGrid.GetSkip()).Take(query.PageSize);
            
            dataGrid.DataContent( filter.ToList());

            return dataGrid;
            */

            return new DataGrid(0, false, 0);
      }
}