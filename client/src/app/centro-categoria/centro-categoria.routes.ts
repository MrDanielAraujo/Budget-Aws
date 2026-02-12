import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroCategoriaFormComponent } from "./centro-categoria-form/centro-categoria-form.component";
import { CentroCategoriaListaComponent } from "./centro-categoria-lista/centro-categoria-lista.component";

export const CENTRO_CATEGORIA_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroCategoriaListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroCategoriaFormComponent, canActivate: [MsalGuard]}
  ]}
]