import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { ComboSeparadorFormComponent } from "./combo-separador-form/combo-separador-form.component";
import { ComboSeparadorListaComponent } from "./combo-separador-lista/combo-separador-lista.component";

export const COMBO_SEPARADOR_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: ComboSeparadorListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: ComboSeparadorFormComponent, canActivate: [MsalGuard]}
  ]}
]