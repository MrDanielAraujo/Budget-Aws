import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { FuncionarioDependenteFormComponent } from "./funcionario-dependente-form/funcionario-dependente-form.component";
import { FuncionarioDependenteListaComponent } from "./funcionario-dependente-lista/funcionario-dependente-lista.component";

export const FUNCIONARIO_DEPENDENTE_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: FuncionarioDependenteListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: FuncionarioDependenteFormComponent, canActivate: [MsalGuard]}
  ]},
]