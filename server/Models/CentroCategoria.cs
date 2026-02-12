using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.Crudl;

namespace server.Models;

public class CentroCategoria : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string? Nome { get; set; }
}