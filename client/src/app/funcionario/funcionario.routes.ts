import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { FuncionarioFormComponent } from "./funcionario-form/funcionario-form.component";
import { FuncionarioListaComponent } from "./funcionario-lista/funcionario-lista.component";

export const FUNCIONARIO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: FuncionarioListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: FuncionarioFormComponent, canActivate: [MsalGuard]}
  ]},
]