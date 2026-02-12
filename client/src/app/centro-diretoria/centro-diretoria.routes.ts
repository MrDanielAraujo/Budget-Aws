import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroDiretoriaFormComponent } from "./centro-diretoria-form/centro-diretoria-form.component";
import { CentroDiretoriaListaComponent } from "./centro-diretoria-lista/centro-diretoria-lista.component";

export const CENTRO_DIRETORIA_ROUTES: Routes =[
  { path: '', children : [
    {path: ':cache', component: CentroDiretoriaListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroDiretoriaFormComponent, canActivate: [MsalGuard]}
  ]},
]