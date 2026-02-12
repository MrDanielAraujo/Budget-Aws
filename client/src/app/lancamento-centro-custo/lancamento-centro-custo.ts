import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class LancamentoCentroCusto { 
    Id !:string;
    IdLancamentoTipo !:string;    
    IdCentroCusto !:string;    
    IdContaContabil !:string;    
    IdExercicio !:string;    
    ValoresJaneiro !:number;    
    ValoresFevereiro !:number;    
    ValoresMarco !:number;    
    ValoresAbril !:number;    
    ValoresMaio !:number;    
    ValoresJunho !:number;    
    ValoresJulho !:number;    
    ValoresAgosto !:number;    
    ValoresSetembro !:number;    
    ValoresOutubro !:number;    
    ValoresNovembro !:number;    
    ValoresDezembro !:number;
    LancamentoTipos !:ComboBoxForm[];
    CentroCustos !:ComboBoxForm[];
    ContaContabeis !:ComboBoxForm[]; 
    Exercicios !:ComboBoxForm[];
} 

export class LancamentoCentroCustoView {
  Total:LancamentoCentroCustoCampos[] = [];
  Fixas:LancamentoCentroCustoCampos[] = [];
  Variaveis:LancamentoCentroCustoCampos[] = [];
} 

export class LancamentoCentroCustoCampos {
  id!:string;
  CodigoContaContabil!:number;
  DigitoContaContabil!:number;
  NomeContaContabil!:string;
  FormulaContaContabil!:string;
  HelpContaContabil!:string;
  LancamentoTipo!:string;
  ValoresJaneiro!:number;
  ValoresFevereiro!:number;
  ValoresMarco!:number;
  ValoresAbril!:number;
  ValoresMaio!:number;
  ValoresJunho!:number;
  ValoresJulho!:number;
  ValoresAgosto!:number;
  ValoresSetembro!:number;
  ValoresOutubro!:number;
  ValoresNovembro!:number; 
  ValoresDezembro!:number;
  Total!:number;
  Media!:number;
  OrcadoReal!:number;
  OrcadoRealPorcento!:number;
  OrcadoForecast!:number;
  OrcadoForecastPorcento!:number;
}