using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaContabilController : CrudController<ContaContabil , ContaContabilQuery>
{
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.ContaContabil!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.Formulas = context.ContaContabilFormula!.Select(x => new ComboBox() { Id = x.Id, Descricao = x.Descricao }).AsNoTrackingWithIdentityResolution().ToList();
            model.Classificacao = context.ContaContabilClassificacao!.Select(x => new ComboBox() { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.ContaContabeis = context.ContaContabil!.Where(x => x.Id != id).Select(x => new ComboBox() { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new ContaContabil()
            {
                  Formulas = context.ContaContabilFormula!.Select(x => new ComboBox() { Id = x.Id, Descricao = x.Descricao }).AsNoTrackingWithIdentityResolution().ToList(),
                  Classificacao = context.ContaContabilClassificacao!.Select(x => new ComboBox() { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  ContaContabeis = context.ContaContabil!.Select(x => new ComboBox() { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
}