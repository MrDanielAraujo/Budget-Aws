import { Routes } from '@angular/router';
import { ExercicioListaComponent } from './exercicio-lista/exercicio-lista.component';
import { ExercicioFormComponent } from './exercicio-form/exercicio-form.component';
import { MsalGuard } from '@azure/msal-angular';

export const EXERCICIO_ROUTES : Routes = [
    {path: '', children : [
        {path: ':cache' , component: ExercicioListaComponent, canActivate: [MsalGuard]},
        {path: 'view/:code', component: ExercicioFormComponent, canActivate: [MsalGuard]}
      ]}
];