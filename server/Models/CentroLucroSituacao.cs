using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroLucroSituacao: ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("Exercicio")]
      public long? IdExercicio { get; set; }

      [ForeignKey("CentroLucro")]
      public long? IdCentroLucro { get; set; }

      [ForeignKey("CentroStatu")]
      public long? IdCentroStatus { get; set; }

      [ForeignKey("CentroLucroUsuario")]
      public long? IdCentroLucroUsuario { get; set; }

      public virtual Exercicio? Exercicio { get; set; }

      public virtual CentroLucro? CentroLucro { get; set; }

      public virtual CentroStatus? CentroStatu { get; set; }

      public virtual CentroLucroUsuario? CentroLucroUsuario { get; set; }

      public virtual List<ComboBox> Exercicios { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroLucros { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroStatus { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroLucroUsuarios { get; set; } = new List<ComboBox>();
}