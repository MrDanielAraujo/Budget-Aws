import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ContaContabilFormComponent } from "./conta-contabil-form/conta-contabil-form.component";
import { ContaContabilListaComponent } from "./conta-contabil-lista/conta-contabil-lista.component";

export const CONTA_CONTABIL_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: ContaContabilListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ContaContabilFormComponent, canActivate: [MsalGuard]}
  ]},
]