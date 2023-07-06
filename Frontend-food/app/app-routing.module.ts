import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BillComponent } from './bill/bill.component';
import { CartComponent } from './cart/cart.component';
import { DashboardComponent } from './home/home.component';
import { LoginComponent } from './Login/Login.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
{path: 'login', component:LoginComponent},
{path: 'home', component:DashboardComponent},
{path:'signup',component:SignupComponent},
{path:'cart',component:CartComponent},
{path: 'bill',component:BillComponent},
{path: '**', pathMatch:'full',redirectTo:'/login'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

