using server.Shared.Crudl;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;
using server.ModelsQuery;
using server.Shared.ValidationError;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExercicioController : CrudController<Exercicio , ExercicioQuery>
{
    protected override bool Validator => false;
    
    [HttpGet("{ano}")]
    public virtual ActionResult<dynamic> HasUniqueKey([FromServices] Context context, [FromRoute] string ano)
    => context.Set<Exercicio>().Any(x => x.Ano.ToUpper() == ano.ToUpper()) ? 
            Ok(true) : Ok(false);
    
    [HttpPut]
    public override ActionResult<dynamic> Update([FromServices] Context context, [FromBody] Exercicio model)
    {
        if (!ModelState.IsValid) return BadRequest(NotValidMsg);

        if (model.Aberto)
        {
            var reg = context.Exercicio!.FirstOrDefault(x => x.Id != model.Id && x.Aberto == true);
            if (reg != null)
            {
                reg.Aberto = false;
                var (sucesso, erro) = context.SaveUpdate(reg);
                if (!sucesso) return BadRequest(new ValidationResultModel([new ValidationError("", erro)]));
            }
        }
        
        var (success, typeError) = context.SaveUpdate(model);
            
        return success ? Ok() : BadRequest(new ValidationResultModel([new ValidationError("", typeError)]));
    } 
    
    [HttpPost]
    [ValidateModel]
    public override ActionResult<dynamic> Create([FromServices] Context context, [FromBody] Exercicio model)
    {
        if( !ModelState.IsValid ) return BadRequest(NotValidMsg);

        if (model.Aberto)
        {
            var reg = context.Exercicio!.FirstOrDefault(x => x.Aberto == true);
            if (reg != null)
            {
                reg.Aberto = false;
                var (sucesso, erro) = context.SaveUpdate(reg);
                if (!sucesso) return BadRequest(new ValidationResultModel([new ValidationError("", erro)]));
            }
        }
        
        var (success,  typeError) = context.SaveCreate(model);

        return success ? Ok() : BadRequest(new ValidationResultModel([new ValidationError("", typeError)]));
    } 
    
}