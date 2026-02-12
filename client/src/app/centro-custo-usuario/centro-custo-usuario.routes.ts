import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroCustoUsuarioFormComponent } from "./centro-custo-usuario-form/centro-custo-usuario-form.component";
import { CentroCustoUsuarioListaComponent } from "./centro-custo-usuario-lista/centro-custo-usuario-lista.component";

export const CENTRO_CUSTO_USUARIO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroCustoUsuarioListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroCustoUsuarioFormComponent, canActivate: [MsalGuard]}
  ]}
]