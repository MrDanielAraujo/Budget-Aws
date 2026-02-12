using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class Produto : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("Mercado")]
      public long? IdMercado { get; set; }

      [ForeignKey("CentroFilial")]
      public long? IdCentroFilial { get; set; }

      public string? Codigo { get; set; }

      public string? Nome { get; set; }

      public string? Linha { get; set; }

      public decimal Custo { get; set; }

      public virtual Mercado? Mercado { get; set; }

      public virtual CentroFilial? CentroFilial { get; set; }

      public virtual List<ComboBox> Mercados { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroFiliais { get; set; } = new List<ComboBox>();
}