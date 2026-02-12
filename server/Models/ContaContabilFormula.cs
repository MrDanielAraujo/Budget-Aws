using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class ContaContabilFormula : ICrud
{
      [Key]
      public long? Id { get; set; }

      [Required]
      public string Formula { get; set; }

      public string Descricao { get; set; }
}