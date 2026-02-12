using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class FuncionarioDependente : ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("Funcionario")]
      public long? IdFuncionario { get; set; }

      [Required]
      public string Nome { get; set; }

      [Column(TypeName = "decimal(18,2)")]
      public decimal PlanoSaudeValor { get; set; }

      public virtual Funcionario? Funcionario { get; set; }

      public virtual List<ComboBox> Funcionarios { get; set; } = new List<ComboBox>();
}