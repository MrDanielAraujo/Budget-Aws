import { ComboBoxForm } from "../shared/form/combobox-form/combobox-form";

export class CentroCusto {
  Id!: string;
  IdCentroClasse!: string;
  IdCentroEmpresa!: string;
  IdCentroFilial!: string;
  IdCentroDiretoria!: string;
  IdCentroCategoria!: string;
  IdCentroLucro!: string;
  Codigo!: string;
  Nome!: string;
  Bloqueado!: boolean;
  NivelTotal!: number
  Classes!: ComboBoxForm [];
  Empresas!: ComboBoxForm [];
  Filiais!: ComboBoxForm [];
  Diretorias!: ComboBoxForm [];
  Categorias!: ComboBoxForm [];
  Lucros!: ComboBoxForm [];
}