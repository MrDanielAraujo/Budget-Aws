import { CentroLucroUsuario } from "../centro-lucro-usuario/centro-lucro-usuario";
import { CentroLucro } from "../centro-lucro/centro-lucro";
import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";
import { Exercicio } from './../exercicio/exercicio';

export class CentroLucroSituacao {
  Id!: string;
  IdExercicio!: string;
  IdCentroLucro!: string;
  IdCentroStatus!: string;
  IdCentroLucroUsuario!: string;
  Exercicios!: ComboBoxForm[];
  CentroLucros!: ComboBoxForm[];
  TipoLancamentos!: ComboBoxForm[];
  CentroStatus!: ComboBoxForm[];
  CentroLucroUsuarios!: ComboBoxForm[];
  CentroLucroUsuario!: CentroLucroUsuario;
  Centro!: CentroLucro;
  Exercicio!: Exercicio;
}