import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class ComboInformacoes {
  Id!: string;
  Nome!: string;
  IdCentroCusto!: string;
  IdComboInformacoesSeparacao!: string;
  CentroCustos!: ComboBoxForm[];
  ComboInformacoesSeparacoes!: ComboBoxForm[];
}