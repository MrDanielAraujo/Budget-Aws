import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ProdutoFormComponent } from "./produto-form/produto-form.component";
import { ProdutoListaComponent } from "./produto-lista/produto-lista.component";

export const PRODUTO_ROUTES:Routes = [
  { path: '', children : [
    {path: ':cache', component: ProdutoListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ProdutoFormComponent, canActivate: [MsalGuard]}
  ]},
]