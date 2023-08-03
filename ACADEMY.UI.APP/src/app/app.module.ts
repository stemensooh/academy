import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    SharedModule,
    AppRoutingModule,
    
    // RouterModule.forRoot(routes, {
    //   useHash: true,
    //   anchorScrolling: 'enabled',
    //   scrollPositionRestoration: 'enabled',
    // }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
