import { Routes } from "@angular/router";
import { LancamentoTipoListaComponent } from "./lancamento-tipo-lista/lancamento-tipo-lista.component";
import { LancamentoTipoFormComponent } from "./lancamento-tipo-form/lancamento-tipo-form.component";
import { MsalGuard } from "@azure/msal-angular";

export const LANCAMENTO_TIPO_ROUTES: Routes = [
    { path: '', children : [
        {path: ':cache', component: LancamentoTipoListaComponent, canActivate: [MsalGuard]},
        {path: 'view/:code', component: LancamentoTipoFormComponent, canActivate: [MsalGuard]}
    ]}
]