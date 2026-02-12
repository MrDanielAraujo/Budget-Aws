import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ComboInformacoesFormComponent } from "./combo-informacoes-form/combo-informacoes-form.component";
import { ComboInformacoesListaComponent } from "./combo-informacoes-lista/combo-informacoes-lista.component";

export const COMBO_INFORMACOES_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: ComboInformacoesListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ComboInformacoesFormComponent, canActivate: [MsalGuard]}
  ]}
]