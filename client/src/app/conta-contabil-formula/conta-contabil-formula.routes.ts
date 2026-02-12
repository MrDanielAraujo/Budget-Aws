import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ContaContabilFormulaFormComponent } from "./conta-contabil-formula-form/conta-contabil-formula-form.component";
import { ContaContabilFormulaListaComponent } from "./conta-contabil-formula-lista/conta-contabil-formula-lista.component";

export const CONTA_CONTABIL_FORMULA_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: ContaContabilFormulaListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ContaContabilFormulaFormComponent, canActivate: [MsalGuard]}
  ]},
]