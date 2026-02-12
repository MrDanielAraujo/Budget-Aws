import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { FuncionarioContratacaoFormComponent } from "./funcionario-contratacao-form/funcionario-contratacao-form.component";
import { FuncionarioContratacaoListaComponent } from "./funcionario-contratacao-lista/funcionario-contratacao-lista.component";

export const FUNCIONARIO_CONTRATACAO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: FuncionarioContratacaoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: FuncionarioContratacaoFormComponent, canActivate: [MsalGuard]}
  ]},
]