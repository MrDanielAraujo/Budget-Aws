import { CentroCustoUsuario } from "../centro-custo-usuario/centro-custo-usuario";
import { CentroCusto } from "../centro-custo/centro-custo";
import { Exercicio } from "../exercicio/exercicio";
import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroCustoSituacao {
  Id!: string;
  IdExercicio!: string;
  IdCentroCusto!: string;
  IdCentroStatus!: string;
  IdCentroCustoUsuario!: string;
  Janeiro!: string;
  Fevereiro!: string;
  Marco!: string;
  Abril!: string;
  Maio!: string;
  Junho!: string;
  Julho!: string;
  Agosto!: string;
  Setembro!: string;
  Outubro!: string;
  Novembro!: string;
  Dezembro!: string;
  Exercicios!: ComboBoxForm[];
  CentroCustos!: ComboBoxForm[];
  LancamentoTipos!: ComboBoxForm[];
  CentroStatus!: ComboBoxForm[];
  CentroCustoUsuarios!: ComboBoxForm[];
  CentroCustoUsuario!: CentroCustoUsuario;
  Exercicio!: Exercicio;
  CentroCusto!: CentroCusto;
}