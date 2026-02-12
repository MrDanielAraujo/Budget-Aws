import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class Funcionario {
  Id!: string;
  Nome!: string;
  IdCentroCusto!: string;
  IdFuncionarioContratacao!: string;
  IdFuncionarioCargo!: string;
  PlanoSaudeValor!: number;
  Periculosidade!: boolean;
  CentroCustos!: ComboBoxForm[];
  FuncionarioCargos!: ComboBoxForm[];
  FuncionariosContratacoes!: ComboBoxForm[];
}