using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class ContaContabil : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("ContaContabilFormula")]
      public long? IdContaContabilFormula { get; set; }

      [ForeignKey("ContaContabilClassificacao")]
      public long? IdContaContabilClassificacao { get; set; }

      [Required]
      public int? Codigo { get; set; }

      [Required]
      public string? Nome { get; set; }

      [Required]
      public string? Limite { get; set; }

      public bool? Visualizar { get; set; }

      public bool? NaoAceitaCalculo { get; set; }

      public bool? ExigeJustificativa { get; set; }

      public string? Help { get; set; }

      public int? Digito { get; set; }

      public virtual ContaContabilFormula? ContaContabilFormula { get; set; }

      public virtual ContaContabilClassificacao? ContaContabilClassificacao { get; set; }

      public virtual List<ComboBox> Formulas { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> Classificacao { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> ContaContabeis { get; set; } = new List<ComboBox>();
}