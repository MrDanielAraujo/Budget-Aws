using server.Interface;

namespace server.ModelsList;

public class CentroCustoLancamentoList
{
    public long? Id { get; set; }
    
    public string? Tipo { get; set; }
    
    public string? CentroCusto { get; set; }
    
    public string? ContaContabil { get; set; }
    
    public string? Exercicio { get; set; }
}

public class CentroCustoLancamentoView
{
    public List<CentroCustoLancamentoCampos> Total { get; set; }
    public List<ICentroCustoLancamentoCampos> Fixas { get; set; }
    public List<ICentroCustoLancamentoCampos> Variaveis { get; set; }
}
public class CentroCustoLancamentoCampos : ICentroCustoLancamentoCampos
{
    public long? Id { get; set; }
    
    public string? LancamentoTipo { get; set; }
    
    public int? CodigoContaContabil { get; set; }
    
    public int? DigitoContaContabil { get; set; }
    
    public string? NomeContaContabil { get; set; }
    
    public string? LimiteContaContabil { get; set; }
    
    public string? HelpContaContabil { get; set; }
    
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
    
    public long? Total { get; set; }
    
    public long? Media { get; set; }
    
    public long? OrcadoReal { get; set; }
    
    public long? OrcadoRealPorcento { get; set; }
    
    public long? OrcadoForecast { get; set; }
    
    public long? OrcadoForecastPorcento { get; set; }
    
    public string? FormulaContaContabil { get; set; }
    
    public long? CodigoContaContabilClassificacao { get; set; } 
    
}

public class CentroCustoLancamentoCamposReal : CentroCustoLancamentoCampos {}

public class CentroCustoLancamentoCamposForecast : CentroCustoLancamentoCampos {}
