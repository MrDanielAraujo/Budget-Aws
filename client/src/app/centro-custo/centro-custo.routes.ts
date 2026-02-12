import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroCustoFormComponent } from "./centro-custo-form/centro-custo-form.component";
import { CentroCustoListaComponent } from "./centro-custo-lista/centro-custo-lista.component";

export const CENTRO_CUSTO_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroCustoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroCustoFormComponent, canActivate: [MsalGuard]}
  ]}
]