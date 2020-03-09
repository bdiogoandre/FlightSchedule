import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { LoginScreenComponent } from './login-screen/login-screen.component';
import { ListFlightsComponent } from './list-flights/list-flights.component';
import { NewFlightComponent } from './new-flight/new-flight.component';
import { PopupsComponent } from './popups/popups.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthconfigInterceptor } from './shared/authconfig.interceptor';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { AuthenticationService } from './shared/authentication.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginScreenComponent,
    ListFlightsComponent,
    NewFlightComponent,
    PopupsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthconfigInterceptor,
      multi: true
    },
    FormBuilder,
    AuthenticationService
  ],
  entryComponents: [PopupsComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
