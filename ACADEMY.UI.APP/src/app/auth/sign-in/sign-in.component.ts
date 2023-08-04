import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { AuthControlService } from '../auth-control.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { AuthResponse } from 'src/app/core/interfaces/auth-response.interface';
import { HttpStatusCode } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.scss'],
})
export class SignInComponent {
  formAuth!: FormGroup;

  constructor(
    private router: Router,
    private control: AuthControlService,
    private authService: AuthService
  ) {
    this.formAuth = this.control.toFormSignIn();
  }

  onSumit() {
    if (!this.valid()) {
      return;
    }

    this.authService
      .signIn({ ...this.formAuth.value })
      .subscribe((response) => {
        if (response.status === HttpStatusCode.Ok) {
          this.authService.setAuthToken(response.body as any);
          this.router.navigate(['/profile']);
        }
      });
  }

  valid() {
    return this.formAuth.valid;
  }
}
