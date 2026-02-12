import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroLucroSituacaoFormComponent } from "./centro-lucro-situacao-form/centro-lucro-situacao-form.component";
import { CentroLucroSituacaoListaComponent } from "./centro-lucro-situacao-lista/centro-lucro-situacao-lista.component";

export const CENTRO_LUCRO_SITUACAO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroLucroSituacaoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroLucroSituacaoFormComponent, canActivate: [MsalGuard]}
  ]},
]