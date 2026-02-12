using System.Net;
using server.Shared.Convert;
using server.Shared.Crudl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Shared.DataGrid;
using server.Shared.Export;
using server.Shared.ValidationError;

namespace server.Controllers;

public abstract class CrudController<T, TY> : ControllerBase where T : class where TY : IDataGrid
{
      protected virtual string NotFoundMsg => "Registro não encontrado.";
      protected virtual string NotValidMsg => "As informações do formulário ainda não são todas validas!";
      protected virtual string NotRemoveMsg => "Não foi possivel remover esse Registro";

      protected virtual bool Validator => true;
      
      [HttpPost]
      [ValidateModel]
      public virtual ActionResult<dynamic> Create([FromServices] Context context, [FromBody] T model)
      {
            if( !ModelState.IsValid ) return BadRequest(NotValidMsg);

            var (success,  typeError) = context.SaveCreate(model);

            return success ? Ok() : BadRequest(new ValidationResultModel([new ValidationError("", typeError)]));
      } 

      [HttpGet("{id:long}")]
      public virtual ActionResult<dynamic> Read([FromServices] Context context, [FromRoute] long id)
      {
            var model = context.Read<T>(id);
            return model == null ? NotFound(NotFoundMsg) : Ok(model);
      }

      [HttpGet]
      public virtual  ActionResult<dynamic> Read([FromServices] Context context) => Ok( (T)Activator.CreateInstance(typeof(T))! );

      [HttpPut]
      public virtual ActionResult<dynamic> Update([FromServices] Context context, [FromBody] T model)
      {
            if (!ModelState.IsValid) return BadRequest(NotValidMsg);
            
            var (success, typeError) = context.SaveUpdate(model);
            
            return success ? Ok() : BadRequest(new ValidationResultModel( new List<ValidationError> { new("", typeError) }));
      } 
      
      [HttpDelete("{ids}")]
      public virtual ActionResult<dynamic> Delete([FromServices] Context context, [FromRoute] string ids) => context.SaveRemove<T>(ids) ? Ok(): BadRequest(NotRemoveMsg);
            
      [HttpGet("Filtrar")]
      public virtual ActionResult<dynamic> ListaFull([FromServices] Context context, [FromQuery] TY query) => Ok(context.ToGrid<T>(query));

      [HttpPost("Import")]
      public virtual ActionResult<dynamic> Import([FromServices] Context context, [FromForm] ICollection<IFormFile> files)
      {
            
            //Console.WriteLine(model);

            var model = typeof(T).Name; //(T)Activator.CreateInstance(typeof(T))!;
        
            var file = files.First();
            //var data = file.OpenReadStream().XlsToDataTable();
            var data = file.OpenReadStream().XlsxToDataTable();

            using (var connection = new SqlConnection(context.Database.GetConnectionString()))
            {
                  using (var sqlBulkCopy = new SqlBulkCopy(connection))
                  {
                        sqlBulkCopy.DestinationTableName = $"bulkcopy.{model}";
                        connection.Open();
                        try
                        {
                              sqlBulkCopy.WriteToServer(data);
                        }
                        catch (Exception e)
                        {
                              return BadRequest(e.Message);
                        }
                        finally
                        {
                              connection.Close();
                        }
                  }

                  try
                  {
                        if (Validator)
                        {
                              var check = $"Carga{model}Validator";
                              context.Database.ExecuteSqlRaw(check);
                        }
                  }
                  catch (Exception e)
                  {
                        return BadRequest(e.Message);
                  }

                  try
                  {
                        var carga = $"Carga{model}";
                        context.Database.ExecuteSqlRaw(carga);
                  }
                  catch (Exception e)
                  {
                        return BadRequest(e.Message);
                  }
            }

            return Ok();
      }

      [HttpGet("ExportToExcel")]
      public virtual ActionResult<dynamic> ExportToExcel([FromServices] Context context)
      {
            var model = typeof(T).Name;
            var exp = new Export();
            exp.AddExcelSheet(context.Set<T>().AsQueryable().AsNoTrackingWithIdentityResolution().ToList(), model);
            var (file, tipo) = exp.ToExcel();
            return File(file, tipo, "Sample.xlsx");
      }
}