import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/Login.component';
import { SignupComponent } from './signup/signup.component';
import { DashboardComponent } from './home/home.component';
import { CartComponent } from './cart/cart.component';
import { BillComponent } from './bill/bill.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedService } from './shared.service';
import { NavbarComponent } from './navbar/navbar.component';
import { NgToastModule } from 'ng-angular-popup';
import { DatePipe } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
      LoginComponent,
      SignupComponent,
      DashboardComponent,
      CartComponent,
      BillComponent,
      NavbarComponent

   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgToastModule
  ],
  providers: [SharedService,DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }


