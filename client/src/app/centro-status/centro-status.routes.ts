import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroStatusFormComponent } from "./centro-status-form/centro-status-form.component";
import { CentroStatusListaComponent } from "./centro-status-lista/centro-status-lista.component";

export const CENTRO_STATUS_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroStatusListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroStatusFormComponent, canActivate: [MsalGuard]}
  ]}
]