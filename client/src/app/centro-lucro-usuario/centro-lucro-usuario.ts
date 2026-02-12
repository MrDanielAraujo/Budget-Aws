import { CentroLucro } from "../centro-lucro/centro-lucro";
import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroLucroUsuario {
  Id!: string;
  IdCentroLucro!: string;
  Email!: string;
  Nivel!: number;
  CentroLucros!: ComboBoxForm [];
  Centro!: CentroLucro;
}