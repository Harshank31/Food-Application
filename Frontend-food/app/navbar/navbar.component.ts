import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../Auth/tokenstorage.service';
import { SharedService } from '../shared.service';
import { NgToastService } from 'ng-angular-popup';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  OrderNo: any;
  CurrentUserId = this.token.getUser().Custid;
  constructor(private token:TokenStorageService, private router:Router,private service:SharedService,private toaster:NgToastService) { }

  CurrentUser = this.token.getUser();

  ngOnInit(): void {
  }

  onLogout(){
    this.token.signOut();
    this.removeFromBillWC;
    this.refreshOrderList;
    this.router.navigate(['/login']);
    this.toaster.success({detail: "User Logout", summary:"Loggedout Successfully", duration: 2000})

  }
  removeFromBillWC(item1: any) {
    this.OrderNo = item1.OrderNo;
    this.service.deleteBillItem(this.OrderNo).subscribe(data => {
      console.log(data.toString());
      this.refreshOrderList();
    });
  }
  refreshOrderList() {
    this.service.getCartUserId(this.CurrentUserId).subscribe(data => {
      this.OrderNo = data;
      console.log(data);
    }
      );
  }


  navigFood(){
    this.router.navigate(['/home']);
  }

  navigCart(){
    this.router.navigate(['/cart']);
  }

  navigBill(){
    this.router.navigate(['/bill']);
  }

}



