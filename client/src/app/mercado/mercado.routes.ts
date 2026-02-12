import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { MercadoFormComponent } from "./mercado-form/mercado-form.component";
import { MercadoListaComponent } from "./mercado-lista/mercado-lista.component";

export const MERCADO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: MercadoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: MercadoFormComponent, canActivate: [MsalGuard]}
  ]},
]