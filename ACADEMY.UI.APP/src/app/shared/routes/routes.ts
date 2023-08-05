import { Routes } from '@angular/router';

export const content: Routes = [
  {
    path: 'home',
    loadChildren: () =>
      import('../../pages/pages.module').then((m) => m.PagesModule),
  },
];
