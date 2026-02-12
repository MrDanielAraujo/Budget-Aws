import { CentroCusto } from "../centro-custo/centro-custo";
import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroCustoUsuario {
  Id!: string;
  IdCentroCusto!: string;
  Email!: string;
  Nivel!: number;
  CentroCustos!: ComboBoxForm [];
  Centro!: CentroCusto;
}