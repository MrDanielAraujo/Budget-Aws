import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class ContaContabil {
  Id!: string;
  IdContaContabilFormula!: string;
  IdContaContabilClassificacao!: string;
  Codigo!: string;
  Nome!: string;
  Limite!: string;
  Visualizar!: boolean;
  Help!: string;
  Digito!: number;
  Formulas!: ComboBoxForm[];
  Classificacao!: ComboBoxForm[];
  NaoAceitaCalculo!: boolean;
  ExigeJustificativa!: boolean;
}