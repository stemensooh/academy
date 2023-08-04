import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AuthControlService } from '../auth-control.service';
import { AuthService } from 'src/app/core/services/auth.service';
import { HttpStatusCode } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss'],
})
export class SignUpComponent {
  formAuth!: FormGroup;

  constructor(
    private router: Router,
    private control: AuthControlService,
    private authService: AuthService
  ) {
    this.formAuth = this.control.toFormSignUp();
  }

  onSumit() {
    console.log('onSumit', this.formAuth.value);
    if (!this.valid()) {
      console.log('form no es valido');
    }

    this.authService
      .signUp({ ...this.formAuth.value })
      .subscribe((response) => {
        console.log(response);
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
