using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroLucroUsuario : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("CentroLucro")]
      public long? IdCentroLucro { get; set; }

      public string? Email { get; set; }

      public int Nivel { get; set; }

      public virtual CentroLucro? CentroLucro { get; set; }

      public virtual List<ComboBox> CentroLucros { get; set; } = new List<ComboBox>();
}