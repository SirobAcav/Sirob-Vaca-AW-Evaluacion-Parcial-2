import { Routes } from '@angular/router';

import { Home } from './pages/home/home';
import { ConferenciasComponent } from './pages/conferencias/conferencias';
import { AsistentesComponent } from './pages/asistentes/asistentes';

export const routes: Routes = [
  {
    path: '',
    component: Home
  },
  {
    path: 'conferencias',
    component: ConferenciasComponent
  },
  {
    path: 'asistentes',
    component: AsistentesComponent
  }
];