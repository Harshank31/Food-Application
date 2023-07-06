import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(private service:SharedService, private router:Router) { }

  Name:string | undefined;

  Phone:number | undefined;
  Email:string | undefined;
  Password:string | undefined;

  UserList:any;

  ngOnInit() {
  }

  signUp(){
    this.UserList ={
      Name: this.Name,
      Phone: this.Phone,
      Email: this.Email,
      Password: this.Password
    }
    this.service.addUser(this.UserList).subscribe(res=>
      alert(res.toString())
    );

  }

}




