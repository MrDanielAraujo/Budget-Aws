import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class FuncionarioDependente {
  Id!: string;
  Nome!: string;
  IdFuncionario!: string;
  PlanoSaudeValor!: number;
  Funcionarios!: ComboBoxForm[];
}