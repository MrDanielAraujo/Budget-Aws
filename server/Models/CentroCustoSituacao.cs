using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroCustoSituacao: ICrud
{
      [Key]
      public long? Id { get; set; }

      [ForeignKey("Exercicio")]
      public long? IdExercicio { get; set; }

      [ForeignKey("CentroCusto")]
      public long? IdCentroCusto { get; set; }

      [ForeignKey("LancamentoTipoJaneiro")]
      public long? Janeiro { get; set; }

      [ForeignKey("LancamentoTipoFevereiro")]
      public long? Fevereiro { get; set; }

      [ForeignKey("LancamentoTipoMarco")]
      public long? Marco { get; set; }

      [ForeignKey("LancamentoTipoAbril")]
      public long? Abril { get; set; }

      [ForeignKey("LancamentoTipoMaio")]
      public long? Maio { get; set; }

      [ForeignKey("LancamentoTipoJunho")]
      public long? Junho { get; set; }

      [ForeignKey("LancamentoTipoJulho")]
      public long? Julho { get; set; }

      [ForeignKey("LancamentoTipoAgosto")]
      public long? Agosto { get; set; }

      [ForeignKey("LancamentoTipoSetembro")]
      public long? Setembro { get; set; }

      [ForeignKey("LancamentoTipoOutubro")]
      public long? Outubro { get; set; }

      [ForeignKey("LancamentoTipoNovembro")]
      public long? Novembro { get; set; }

      [ForeignKey("LancamentoTipoDezembro")]
      public long? Dezembro { get; set; }

      [ForeignKey("CentroStatu")]
      public long? IdCentroStatus { get; set; }

      [ForeignKey("CentroCustoUsuario")]
      public long? IdCentroCustoUsuario { get; set; }
      
      public virtual Exercicio? Exercicio { get; set; }

      public virtual CentroCusto? CentroCusto { get; set; }

      public virtual CentroStatus? CentroStatu { get; set; }

      public virtual LancamentoTipo? LancamentoTipoJaneiro { get; set; }

      public virtual LancamentoTipo? LancamentoTipoFevereiro { get; set; }

      public virtual LancamentoTipo? LancamentoTipoMarco { get; set; }

      public virtual LancamentoTipo? LancamentoTipoAbril { get; set; }

      public virtual LancamentoTipo? LancamentoTipoMaio { get; set; }

      public virtual LancamentoTipo? LancamentoTipoJunho { get; set; }

      public virtual LancamentoTipo? LancamentoTipoJulho { get; set; }

      public virtual LancamentoTipo? LancamentoTipoAgosto { get; set; }

      public virtual LancamentoTipo? LancamentoTipoSetembro { get; set; }

      public virtual LancamentoTipo? LancamentoTipoOutubro { get; set; }

      public virtual LancamentoTipo? LancamentoTipoNovembro { get; set; }

      public virtual LancamentoTipo? LancamentoTipoDezembro { get; set; }

      public virtual CentroCustoUsuario? CentroCustoUsuario { get; set; }

      public virtual List<ComboBox> Exercicios { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroCustos { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> LancamentoTipos { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroStatus { get; set; } = new List<ComboBox>();

      public virtual List<ComboBox> CentroCustoUsuarios { get; set; } = new List<ComboBox>();
}