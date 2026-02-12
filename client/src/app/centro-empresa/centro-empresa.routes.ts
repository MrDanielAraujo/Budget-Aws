import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroEmpresaFormComponent } from "./centro-empresa-form/centro-empresa-form.component";
import { CentroEmpresaListaComponent } from "./centro-empresa-lista/centro-empresa-lista.component";

export const CENTRO_EMPRESA_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroEmpresaListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroEmpresaFormComponent, canActivate: [MsalGuard]}
  ]}
]