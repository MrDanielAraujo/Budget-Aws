using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroCustoUsuario : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("CentroCusto")]
      public long? IdCentroCusto { get; set; }

      public string? Email { get; set; }

      public long? Nivel { get; set; } = 0;

      public virtual CentroCusto? CentroCusto { get; set; }

      public virtual List<ComboBox> CentroCustos { get; set; } = new List<ComboBox>();
}