using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class CentroEmpresa : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string Codigo { get; set; }

      [Required]
      public string Nome { get; set; }

      public string? NomeReal { get; set; }
}