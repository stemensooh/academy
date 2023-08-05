import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { ContentComponent } from './shared/components/layout/content/content.component';
import { content } from './shared/routes/routes';
import { authGuard } from './shared/guard/auth.guard';


export const routes: Routes = [
  // {
  //   path: '',
  //   component: AuthComponent,
  //   canMatch: [authGuard]
  // },
  {
    path: '',
    component: ContentComponent,
    canActivate: [authGuard],
    children: content
  },
  {
    path: 'auth',
    component: AuthComponent,
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
    data: {
      breadcrumb: "auth"
    }
  },
  // {
  //   path: '**',
  //   redirectTo: ''
  // },
  {
    path: '',
    redirectTo: 'auth',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [[RouterModule.forRoot(routes, {
    anchorScrolling: 'enabled',
    scrollPositionRestoration: 'enabled',
})],
],
  exports: [RouterModule]
})
export class AppRoutingModule { }

