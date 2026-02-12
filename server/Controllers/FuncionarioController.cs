using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ComboBox;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : CrudController<Funcionario , FuncionarioQuery>
{
      [HttpGet("{id:long}")]
      public override ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.Funcionario!.Include(x => x.FuncionariosDependentes).FirstOrDefault(x => x.Id == id);

            if (model == null) return NotFound(NotFoundMsg);

            model.CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.FuncionarioCargos = context.FuncionarioCargo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            model.FuncionariosContratacoes = context.FuncionarioContratacao!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList();
            
            return  Ok(model);
      }
      
      [HttpGet]
      public override ActionResult<dynamic> Read([FromServices] Context context)
      {
            var model = new Funcionario
            {
                  CentroCustos = context.CentroCusto!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  FuncionarioCargos = context.FuncionarioCargo!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList(),
                  FuncionariosContratacoes = context.FuncionarioContratacao!.Select(x => new ComboBox { Id = x.Id, Descricao = x.Nome }).AsNoTrackingWithIdentityResolution().ToList()
            };
            
            return  Ok(model);
      }
}