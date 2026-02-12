using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class Mercado : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string Nome { get; set; }
}