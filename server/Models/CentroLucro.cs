using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroLucro : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("CentroClasse")]
      public long? IdCentroClasse { get; set; }

      [ForeignKey("CentroEmpresa")]
      public long? IdCentroEmpresa { get; set; }

      [ForeignKey("CentroFilial")]
      public long? IdCentroFilial { get; set; }

      [ForeignKey("CentroDiretoria")]
      public long? IdCentroDiretoria { get; set; }

      [ForeignKey("CentroCategoria")]
      public long? IdCentroCategoria { get; set; }

      public string Codigo { get; set; }

      public string Nome { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? Imposto { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal? Pdd { get; set; }

      public bool Bloqueado { get; set; }
      
      public long? NivelTotal { get; set; } = 0;

      // public string PreenchedorEmail { get; set; }

      public virtual CentroClasse? CentroClasse { get; set; }

      public virtual CentroEmpresa? CentroEmpresa { get; set; }

      public virtual CentroFilial? CentroFilial { get; set; }

      public virtual CentroDiretoria? CentroDiretoria { get; set; }

      public virtual CentroCategoria? CentroCategoria { get; set; }

      public virtual List<ComboBox> Classes { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> Empresas { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> Filiais { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> Diretorias { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> Categorias { get; set; } = new List<ComboBox>();
}
      