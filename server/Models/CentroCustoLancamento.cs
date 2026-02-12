using System.ComponentModel.DataAnnotations.Schema;
using server.Shared.ComboBox;
using server.Shared.Crudl;

namespace server.Models;

public class CentroCustoLancamento : ICrud
{
    public long? Id { get; set; }
    
    [ForeignKey("LancamentoTipo")]
    public long? IdLancamentoTipo { get; set; }
    
    [ForeignKey("CentroCusto")]
    public long? IdCentroCusto { get; set; }
    
    [ForeignKey("ContaContabil")]
    public long? IdContaContabil { get; set; }
    
    [ForeignKey("Exercicio")]
    public long? IdExercicio { get; set; }
    
    public long? ValoresJaneiro { get; set; }
    
    public long? ValoresFevereiro { get; set; }
    
    public long? ValoresMarco { get; set; }
    
    public long? ValoresAbril { get; set; }
    
    public long? ValoresMaio { get; set; }
    
    public long? ValoresJunho { get; set; }
    
    public long? ValoresJulho { get; set; }
    
    public long? ValoresAgosto { get; set; }
    
    public long? ValoresSetembro { get; set; }
    
    public long? ValoresOutubro { get; set; }
    
    public long? ValoresNovembro { get; set; }
    
    public long? ValoresDezembro { get; set; }
    
    public virtual LancamentoTipo? LancamentoTipo { get; set; }
    
    public virtual CentroCusto? CentroCusto { get; set; }
    
    public virtual ContaContabil? ContaContabil { get; set; }
    
    public virtual Exercicio? Exercicio { get; set; }
    
    public virtual List<ComboBox> LancamentoTipos { get; set; } = new List<ComboBox>();
    
    public virtual List<ComboBox> CentroCustos { get; set; } = new List<ComboBox>();
    
    public virtual List<ComboBox> ContaContabeis { get; set; } = new List<ComboBox>();
    
    public virtual List<ComboBox> Exercicios { get; set; } = new List<ComboBox>();
}