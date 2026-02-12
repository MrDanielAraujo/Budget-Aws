import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { LancamentoCentroCustoFormComponent } from "./lancamento-centro-custo-form/lancamento-centro-custo-form.component";
import { LancamentoCentroCustoListaComponent } from "./lancamento-centro-custo-lista/lancamento-centro-custo-lista.component";
import { LancamentoCentroCustoComponent } from "./lancamento-centro-custo.component";

export const LANCAMENTO_CENTRO_CUSTO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: LancamentoCentroCustoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: LancamentoCentroCustoFormComponent, canActivate: [MsalGuard]},
    {path: ':centro/:ano', component: LancamentoCentroCustoComponent, canActivate: [MsalGuard]}
  ]},
]