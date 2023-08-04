import { CanActivateChildFn, CanActivateFn, CanMatchFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const usuarioToken =  authService.getAuthToken();
  return usuarioToken ? true : false
};
