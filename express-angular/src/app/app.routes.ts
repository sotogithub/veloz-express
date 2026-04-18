import { Routes } from '@angular/router';

export const routes: Routes = [
  // Módulos independientes (primero)
  {
    path: 'auth',
    loadChildren: () => import('./domains/auth/routes'),
  },
  {
    path: 'admin',
    loadChildren: () => import('./domains/admin/routes'),
  },
  // Coming soon
  {
    path: 'coming-soon',
    loadChildren: () => import('./domains/coming-soon/routes'),
  },

  // Layout público (al final)
  {
    path: '',
    loadChildren: () => import('./domains/website/routes'),
  },

  { path: '**', redirectTo: '' },
];
