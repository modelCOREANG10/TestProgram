import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { Comp1Component } from './Components/comp1/comp1.component';
import { Comp2Component } from './Components/comp2/comp2.component';
import { TestService } from './_services/test.service';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './_services/user.service';
import { EmailService } from './_services/Email.service';


@NgModule({
  declarations: [
    AppComponent,
    Comp1Component,
    Comp2Component,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FlexLayoutModule,
    FormsModule,
  ],
  providers: [
    TestService,
    UserService,
    EmailService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
