import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class Produto {
  Id!: string;
  IdCentroFilial!: string;
  IdMercado!: string;
  Codigo!: string;
  Nome!: string;
  Linha!: string;
  Custo!: number;
  CentroFiliais!: ComboBoxForm [];
  Mercados!: ComboBoxForm [];
}