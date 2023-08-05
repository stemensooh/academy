import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AppService } from '../../app.service';

export const authGuard: CanActivateFn = (route, state) => {
  const service = inject(AppService);

  if (
    !route.toString() ||
    route.toString() == '/' ||
    route.toString().includes('recuperar')
  ) {
    return !service.isValidToken();
  } else {
    return service.isValidToken();
  }
};
