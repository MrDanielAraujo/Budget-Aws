import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroCustoSituacaoFormComponent } from "./centro-custo-situacao-form/centro-custo-situacao-form.component";
import { CentroCustoSituacaoListaComponent } from "./centro-custo-situacao-lista/centro-custo-situacao-lista.component";

export const CENTRO_CUSTO_SITUACAO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroCustoSituacaoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroCustoSituacaoFormComponent, canActivate: [MsalGuard]}
  ]}
]