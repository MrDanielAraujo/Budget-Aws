import { Routes } from "@angular/router";
import { ContaContabilClassificacaoListaComponent } from "./conta-contabil-classificacao-lista/conta-contabil-classificacao-lista.component";
import { ContaContabilClassificacaoFormComponent } from "./conta-contabil-classificacao-form/conta-contabil-classificacao-form.component";
import { MsalGuard } from "@azure/msal-angular";

export const CONTA_CONTABIL_CLASSIFICACAO_ROUTES : Routes = [
    { path: '', children : [
        {path: ':cache', component: ContaContabilClassificacaoListaComponent, canActivate: [MsalGuard]},
        {path: 'view/:code', component: ContaContabilClassificacaoFormComponent, canActivate: [MsalGuard]}
    ]}
];