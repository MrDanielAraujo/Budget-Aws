import { CentroEmpresa } from "../centro-empresa/centro-empresa";
import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroFilial {
  Id!: string;
  Codigo!: string;
  Nome!: string;
  IdEmpresa!: string;
  Empresa!: CentroEmpresa;
  Empresas!: ComboBoxForm [];
}