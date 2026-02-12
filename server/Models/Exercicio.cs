using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class Exercicio : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required(ErrorMessage = "required")]
      [RegularExpression(@"^\d{4}$", ErrorMessage = "mask")]
      [Range(1, 2024, ErrorMessage = "range")]
      public string Ano { get; set; }

      public bool Aberto { get; set; }
}