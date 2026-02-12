using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CentroLucroController : CrudController<CentroLucro , CentroLucroQuery>
{
      
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.CentroLucro!.Find(id);

            if (model == null) return NotFound(NotFoundMsg);

            model.Classes = context.CentroClasse!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Empresas = context.CentroEmpresa!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Filiais = context.CentroFilial!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Diretorias = context.CentroDiretoria!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.Categorias = context.CentroCategoria!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new CentroLucro
            {
                  Classes = context.CentroClasse!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Empresas = context.CentroEmpresa!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Filiais = context.CentroFilial!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Diretorias = context.CentroDiretoria!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  Categorias = context.CentroCategoria!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };

            return  Ok(model);
      }
}