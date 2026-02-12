using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class Funcionario : ICrud
{
      public Funcionario()
      {
            FuncionariosDependentes = new HashSet<FuncionarioDependente>();
            
      }

      [Key]
      public long? Id { get; set; }

      [ForeignKey("CentroCusto")]
      public long? IdCentroCusto { get; set; }

      [ForeignKey("FuncionarioContratacao")]
      public long? IdFuncionarioContratacao { get; set; }

      [ForeignKey("FuncionarioCargo")]
      public long? IdFuncionarioCargo { get; set; }

      [Required]
      public string Nome { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal PlanoSaudeValor { get; set; }

      public bool Periculosidade { get; set; }

      public virtual CentroCusto? CentroCusto { get; set; }

      public virtual FuncionarioCargo? FuncionarioCargo { get; set; }

      public virtual FuncionarioContratacao? FuncionarioContratacao { get; set; }

      public virtual List<ComboBox> CentroCustos { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> FuncionarioCargos { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> FuncionariosContratacoes { get; set; } = new List<ComboBox>();

      public virtual ICollection<FuncionarioDependente> FuncionariosDependentes { get; set; }
}