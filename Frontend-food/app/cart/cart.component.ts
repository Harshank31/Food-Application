import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../Auth/tokenstorage.service';
import { SharedService } from '../shared.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit
{

  constructor(private service: SharedService, private token: TokenStorageService,private toastr: NgToastService,public route:Router) { }
  CurrentAddress=this.token.getUser().CustAddress;
  CurrentUserId = this.token.getUser().Custid;
  CartList: any = [];
  CartId: number = 0;
  CartId1: number = 0;
  subTot: number = 0;

  Tot: number = 0;
  PartTotal: number = 0;

  ngOnInit(): void {
    this.refreshCartList();
  }

  getSubTotal() {
    return this.CartList.reduce((sum: number, current: any) => sum + current.Price * current.Quantity, 0);
  }



  getTotal() {
    this.subTot = this.getSubTotal();

    return this.Tot = this.subTot;
  }

  refreshCartList()
  {
    this.service.getCartUserId(this.CurrentUserId).subscribe(data =>
      {
        this.CartList = data;
        console.log(data);
      }
      );
  }


  removeFromCart(item1: any) {
    this.CartId = item1.CartId;
    if (this.toastr) {
      this.service.deleteCartItem(this.CartId).subscribe(data => {
        this.toastr.success({detail:" Please Add food from cart ",summary:"Removed Successfully From Your Cart",duration:2000})
        this.refreshCartList();
      });
    }
  }

  removeFromCartWC(item1: any) {
    this.CartId1 = item1.CartId;
    this.service.deleteCartItem(this.CartId1).subscribe(data => {
      console.log(data.toString());
      this.refreshCartList();
    });
  }

  generateBill() {
    let no=Math.floor(Math.random() * 1000)
    this.CartList.forEach((cart: any) => {
      this.PartTotal = this.subTot;
      let order = {
        OrderNo:no,
        Custid: this.CurrentUserId,
        FoodCode: cart.FoodCode,
        FoodName: cart.FoodName,
        Price: cart.Price,
        Total: this.PartTotal,
        quantity : cart.Quantity,
        CustAddress:this.CurrentAddress
      }
      this.service.addBillingDetail(order).subscribe(res => {
        this.toastr.success({detail:" Pay Cash!",summary:"Bill Generated Successfully",duration:2000})
        console.log(res.toString());
      });
      this.removeFromCartWC(cart);
    });
    this.refreshCartList();
    this.route.navigateByUrl('/bill');
  }

  increQty(item: any) {
    item.Quantity = item.Quantity + 1;
  }
  decQty(item: any) {
    if(item.Quantity>1){
      item.Quantity = item.Quantity - 1;
    }
    else{
      this.removeFromCart(item);
    }

  }

}



