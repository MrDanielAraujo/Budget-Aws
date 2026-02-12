import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ParametroFormComponent } from "./parametro-form/parametro-form.component";
import { ParametroListaComponent } from "./parametro-lista/parametro-lista.component";

export const PARAMETRO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: ParametroListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ParametroFormComponent, canActivate: [MsalGuard]}
  ]},
]