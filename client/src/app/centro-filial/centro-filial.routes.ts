import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroFilialFormComponent } from "./centro-filial-form/centro-filial-form.component";
import { CentroFilialListaComponent } from "./centro-filial-lista/centro-filial-lista.component";

export const CENTRO_FILIAL_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroFilialListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroFilialFormComponent, canActivate: [MsalGuard]}
  ]},
]