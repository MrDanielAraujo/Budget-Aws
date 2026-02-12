using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class Parametro : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string Nome { get; set; }

      [Required]
      public string Valor { get; set; }
}