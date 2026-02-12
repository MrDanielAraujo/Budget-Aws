using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : CrudController<Produto , ProdutoQuery>
{
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.Produto!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroFiliais = context.CentroFilial!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Mercados = context.Mercado!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new Produto
            {
                  CentroFiliais = context.CentroFilial!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Mercados = context.Mercado!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
}