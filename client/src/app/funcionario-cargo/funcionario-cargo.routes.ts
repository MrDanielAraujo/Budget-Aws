import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { FuncionarioCargoFormComponent } from "./funcionario-cargo-form/funcionario-cargo-form.component";
import { FuncionarioCargoListaComponent } from "./funcionario-cargo-lista/funcionario-cargo-lista.component";

export const FUNCIONARIO_CARGO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: FuncionarioCargoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: FuncionarioCargoFormComponent, canActivate: [MsalGuard]}
  ]},
]