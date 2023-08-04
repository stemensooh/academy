import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  // constructor(private auth: AppService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    // const user = this.auth.user_logged;
    // if (user) {
    //   const authReq = req.clone({ setHeaders: { 'Authorization': 'Bearer ' + user.token } });
    //   return next.handle(authReq);
    // }
    return next.handle(req);
  }
}
