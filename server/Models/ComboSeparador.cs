using System.ComponentModel.DataAnnotations;
using server.Shared.Crudl;

namespace server.Models;

public class ComboSeparador : ICrud
{
      [Key]
      public long? Id { get; set; }

      public string? Nome { get; set; }
      
      public string? Icone { get; set; }
}