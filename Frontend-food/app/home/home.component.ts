import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../Auth/tokenstorage.service';
import { SharedService } from '../shared.service';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-dashboard',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private service:SharedService, private token:TokenStorageService,private toastr:NgToastService) { }
  FoodCodeFilter:string="";
  FoodNameFilter:string="";
  FoodListWithoutFilter:any;

  menu:any=[];
  UserID = this.token.getUser().Custid;
  menus:any;
  menu1:any;

  ngOnInit(): void {
    this.refreshmenu();
  }

  refreshmenu(){
    this.service.getmenu().subscribe(data=>{
      this.menu=data;
      this.FoodListWithoutFilter=data;
    });
  }

  addToCart(item1:any){
    this.menus = item1;
    this.menu1 = {
      Custid: this.UserID,
      FoodCode: this.menus.FoodCode,
      FoodName: this.menus.FoodName,
      Description: this.menus.Description,
      Quantity:1,
      Price: this.menus.Price

    };
    this.service.addCart(this.menu1).subscribe(res=>
      {
        this.toastr.success({detail:"Hey Foodie! ",summary:res.toString(),duration:2000})
      });
  }

  FilterFn(){
    var FoodCodeFilter = this.FoodCodeFilter;
    var FoodNameFilter = this.FoodNameFilter;
    this.menu = this.FoodListWithoutFilter.filter(function (el:any){
      return el.FoodCode.toString().toLowerCase().includes(
        FoodCodeFilter.toString().trim().toLowerCase()
      )&&
      el.FoodName.toString().toLowerCase().includes(
        FoodNameFilter.toString().trim().toLowerCase()
      )
    });


  }sortResult(prop:any,asc: any){
    this.menu = this.FoodListWithoutFilter.sort(function(a:any,b:any){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }

}

