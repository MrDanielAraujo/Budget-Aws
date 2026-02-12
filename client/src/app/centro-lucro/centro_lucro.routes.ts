import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroLucroFormComponent } from "./centro-lucro-form/centro-lucro-form.component";
import { CentroLucroListaComponent } from "./centro-lucro-lista/centro-lucro-lista.component";

export const CENTRO_LUCRO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroLucroListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroLucroFormComponent, canActivate: [MsalGuard]}
  ]},
]