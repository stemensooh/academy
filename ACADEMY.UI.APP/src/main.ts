import { LOCALE_ID, enableProdMode, importProvidersFrom } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import { httpInterceptorProviders } from './app/core/http-interceptors/index';
import { HttpErrorHandlerService } from './app/core/services/http-error-handler.service';
import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { AppRoutingModule } from './app/app-routing.module';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { registerLocaleData } from '@angular/common';
import localeEC from '@angular/common/locales/es-EC';
import { provideAnimations } from '@angular/platform-browser/animations';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href + 'api/';
}

if (environment.production) {
  enableProdMode();
}

registerLocaleData(localeEC, 'es-EC');

bootstrapApplication(AppComponent, {
    providers: [
      importProvidersFrom(
        BrowserModule, 
        // MatSnackBarModule, 
        AppRoutingModule
        ),
      { provide: LOCALE_ID, useValue: 'es-EC' },
      { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
      HttpErrorHandlerService,
      httpInterceptorProviders,
      provideHttpClient(withInterceptorsFromDi()),
      provideAnimations()

    ],
  })
  .catch((err) => console.error(err));
