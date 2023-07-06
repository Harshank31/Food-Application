import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../Auth/tokenstorage.service';
import { SharedService } from '../shared.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit
{

  constructor(private service:SharedService, private router:Router, private token:TokenStorageService, private toaster:NgToastService) { }

  CustName:string | undefined;
  CustPassword:string | undefined;
  LArray:any;

  ngOnInit(): void {
    const token = this.token.getToken();
    if(token != null)
    { this.router.navigateByUrl('dashboard') }
  }

  cLog()
  {
    this.LArray={
      CustName: this.CustName,
      CustPassword: this.CustPassword
    }
    this.service.login(this.LArray).subscribe
    (
      (res:any)=>
      {
        this.token.saveToken(res.token)
        this.token.saveUser(res)
        this.toaster.success({detail:"Hey Foodie",summary:"Login Successfully",duration:2000})
        this.router.navigateByUrl('/home');
      },
      err => {
        if(err.status == 401)
        this.toaster.error({detail:"Forget!",summary:"Sorry User or Password Incorrect",duration:2000})
        else
          console.log(err);
      }
    );
  }
}




