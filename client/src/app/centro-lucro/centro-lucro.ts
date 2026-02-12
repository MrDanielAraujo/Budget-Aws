import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroLucro {
  Id!: string;
  IdCentroClasse!: string;
  IdCentroEmpresa!: string;
  IdCentroFilial!: string;
  IdCentroDiretoria!: string;
  IdCentroCategoria!: string;
  Codigo!: string;
  Nome!: string;
  Imposto!: number;
  Pdd!: number;
  Bloqueado!: boolean;
  // PreenchedorEmail!: string;
  Classes!: ComboBoxForm [];
  Empresas!: ComboBoxForm [];
  Filiais!: ComboBoxForm [];
  Diretorias!: ComboBoxForm [];
  Categorias!: ComboBoxForm [];
}