using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class LancamentoTipo : ICrud
{
      [Key]
      public long? Id { get; set; }

      public string Nome { get; set; }
      
      public long Codigo { get; set; }
}