import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import {
  HandleError,
  HttpErrorHandlerService,
} from './http-error-handler.service';
import { Observable, of } from 'rxjs';
import { HttpResult, httpOptions } from '../models/http';
import { catchError } from 'rxjs/operators';
import { SignUpDto } from '../dtos/auth/sign-up.dto';
import { SignInDto } from '../dtos/auth/sign-in.dto';
import { AuthResponse } from '../interfaces/auth-response.interface';
import jwt_decode from 'jwt-decode';
import { UsuarioToken } from '../interfaces/usuario-token.interface';
import { Captcha } from '../interfaces/utils';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url: string;
  private handleError!: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandlerService
  ) {
    this.handleError = httpErrorHandler.createHandleError('AuthService');
    this.url = '/api/auth';
  }

  getCaptchaConfig = () => this.http.get<Captcha>(`${this.url}/captcha`)
    .pipe(catchError(this.handleError<Captcha>('getCaptchaConfig')));

  signIn(model: SignInDto): Observable<HttpResponse<HttpResult>> {
    const url = `${this.url}/login`;
    return this.http
      .post<HttpResult>(url, model, httpOptions)
      .pipe(catchError(this.handleError<HttpResponse<HttpResult>>('signIn')));
  }

  signUp(model: SignUpDto): Observable<HttpResponse<HttpResult>> {
    const url = `${this.url}/sign-up`;
    return this.http
      .post<HttpResult>(url, model, httpOptions)
      .pipe(catchError(this.handleError<HttpResponse<HttpResult>>('signUp')));
  }

  signOut(){
    localStorage.removeItem('access_token');
  }

  getAuthToken() {
    const token = localStorage.getItem('access_token')  ?? '';
    return jwt_decode(token) as UsuarioToken;
  }

  setAuthToken(authResponse: AuthResponse){
    const valid = jwt_decode(authResponse.access_token);
      if (valid) {
        localStorage.setItem('access_token', authResponse.access_token);
        return true;
      }

    return false;
  }

  
}
