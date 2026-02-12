import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroClasseFormComponent } from "./centro-classe-form/centro-classe-form.component";
import { CentroClasseListaComponent } from "./centro-classe-lista/centro-classe-lista.component";

export const CENTRO_CLASSE_ROUTES: Routes = [
  { path: '', children : [
    {path: ':cache', component: CentroClasseListaComponent, canActivate: [MsalGuard]},
    {path: 'view/:code', component: CentroClasseFormComponent, canActivate: [MsalGuard]}
  ]}
]