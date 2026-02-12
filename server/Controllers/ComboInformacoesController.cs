using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComboInformacoesController : CrudController<ComboInformacoes , ComboInformacoesQuery>
{
    
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.ComboInformacoes!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.ComboInformacoesSeparacoes = context.ComboSeparador!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new ComboInformacoes
            {
                  CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  ComboInformacoesSeparacoes = context.ComboSeparador!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
            };

            return  Ok(model);
      }
}