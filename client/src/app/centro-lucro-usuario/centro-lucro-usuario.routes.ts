import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroLucroUsuarioFormComponent } from "./centro-lucro-usuario-form/centro-lucro-usuario-form.component";
import { CentroLucroUsuarioListaComponent } from "./centro-lucro-usuario-lista/centro-lucro-usuario-lista.component";

export const CENTRO_LUCRO_USUARIO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroLucroUsuarioListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroLucroUsuarioFormComponent, canActivate: [MsalGuard]}
  ]}
]