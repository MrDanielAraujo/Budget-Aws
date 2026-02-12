import { Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";
import { CentroCustoComponent } from "./centro-custo/centro-custo.component";
import { CentroLucroComponent } from "./centro-lucro/centro-lucro.component";
import { HomeComponent } from "./home.component";

export const HOME_ROUTES : Routes = [
    {path: "", component: HomeComponent, children : [
        {path: '' , component: CentroCustoComponent, canActivate: [MsalGuard]},
        {path: 'CentroLucro' , component: CentroLucroComponent, canActivate: [MsalGuard]},
        {path: 'CentroCusto' , component: CentroCustoComponent, canActivate: [MsalGuard]},
    ]}
];