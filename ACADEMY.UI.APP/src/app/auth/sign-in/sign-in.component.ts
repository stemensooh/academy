import { Component, Inject, NgZone, Renderer2, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuthControlService } from '../auth-control.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subscription } from 'rxjs';
import { DOCUMENT } from '@angular/common';
import { SignInDto } from 'src/app/core/dtos/auth/sign-in.dto';
import { AppService } from '../../app.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss'],
})
export class SignInComponent implements OnInit {
  formAuth!: FormGroup;

  hide: boolean = true;
  isLoading: boolean = true;
  isLogin: boolean = false;
  private captchaHabilitado: boolean = true;
  private readySubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(
    false
  );
  private subscription: Subscription | null = null;
  private widgetDivReCaptchaGoogle: any = null;
  private parentrecaptcha: any = null;
  private recaptcha: any = null;

  constructor(
    @Inject(DOCUMENT) private document: Document,
    private appService: AppService,
    private render: Renderer2,
    private router: Router,
    private control: AuthControlService,
    private authService: AuthService,
    private zone: NgZone
  ) {
    this.formAuth = this.control.toFormSignIn();
  }

  ngOnInit(): void {
    this.authService.getCaptchaConfig().subscribe((captcha) => {
      this.captchaHabilitado = captcha.captchaHabilitado;
      if (this.captchaHabilitado) {
        window[<any>'onloadCallback'] = <any>(
          (() => this.zone.run(this.onloadCallback.bind(this)))
        );
        this.subscription = this.loadCaptcha().subscribe((isFinish) => {
          if (isFinish) {
            this.widgetDivReCaptchaGoogle = this.renderCaptcha(
              captcha.captchaSitio
            );
            this.isLoading = false;
          }
        });
      } else {
        this.isLoading = false;
      }
    });
  }

  ngOnDestroy(): void {
    if (this.captchaHabilitado) {
      this.resetCaptcha();
      this.subscription && this.subscription.unsubscribe();
      this.render.removeChild(this.parentrecaptcha, this.recaptcha);
    }
  }

  private onloadCallback() {
    this.readySubject.next(true);
  }

  private loadCaptcha(): Observable<boolean> {
    this.parentrecaptcha = this.document.getElementById('body-academy');
    this.recaptcha = this.render.createElement('script');
    this.recaptcha.src =
      'https://www.google.com/recaptcha/api.js?hl=es&onload=onloadCallback&render=explicit';
    this.recaptcha.async = true;
    this.recaptcha.defer = true;
    this.render.appendChild(this.parentrecaptcha, this.recaptcha);
    return this.readySubject.asObservable();
  }

  private renderCaptcha(sitekey: string) {
    return (<any>window).grecaptcha.render('DivReCaptchaGoogle', {
      sitekey: sitekey,
      theme: 'light',
      'expired-callback': this.resetCaptcha,
    });
  }

  private resetCaptcha() {
    this.zone.runOutsideAngular(() =>
      (<any>window).grecaptcha.reset(this.widgetDivReCaptchaGoogle)
    );
  }

  private getCaptcha(): string {
    return (<any>window).grecaptcha.getResponse(this.widgetDivReCaptchaGoogle);
  }

  onSumit() {
    if (!this.valid()) {
      return;
    }

    let captcha: string = '';
    if (this.captchaHabilitado && (captcha = this.getCaptcha()) == '') {
      // this.snackBar.open('El captcha es incorrecto', 'Error', {
      //   duration: 2500,
      //   panelClass: ['error'],
      // });
    } else {
      if (this.formAuth.valid) {
        this.isLogin = true;
        const user: SignInDto = this.formAuth.getRawValue();
        user.captcha = captcha;
        this.authService.signIn(user).subscribe((response: any) => {
          if (response.status == 200) {
            this.appService.saveToken(response.body);
            this.router.navigate(['/home']);
          } else {
            this.captchaHabilitado && this.resetCaptcha();
            this.isLogin = false;
          }
        });
      }
    }

    // this.authService
    //   .signIn({ ...this.formAuth.value })
    //   .subscribe((response) => {
    //     if (response.status === HttpStatusCode.Ok) {
    //       this.authService.setAuthToken(response.body as any);
    //       this.router.navigate(['/profile']);
    //     }
    //   });
  }

  valid() {
    return this.formAuth.valid;
  }
}
