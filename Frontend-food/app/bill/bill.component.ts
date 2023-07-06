import { DatePipe } from '@angular/common'
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TokenStorageService } from '../Auth/tokenstorage.service';
import { SharedService } from '../shared.service';



@Component({
  selector: 'app-bill',
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css']
})
export class BillComponent implements OnInit {

  constructor(private service:SharedService, private token:TokenStorageService,
    private router: Router,
    public datePipe: DatePipe) {}

  OrderList:any=[];
  CurrentUserId = this.token.getUser().Custid;
  CurrentUser = this.token.getUser();
  OrderNo1:number=0;
  PartTotal:number=0;
  datepipe: DatePipe = new DatePipe('en-US');

  ngOnInit(): void {
    this.refreshBillList();
  }
  getFormattedDate(){
    var date = new Date();
    var transformDate = this.datePipe.transform(date, 'yyyy-MM-dd');
    return transformDate;
  }

  getTotal(bill:any){
    return bill.reduce((sum:number, current:any) => sum + current.Price * current.Quantity, 0);
  }

  refreshBillList(){
    this.service.getBillingDetail(this.CurrentUserId).subscribe(data=>
    this.OrderList=data);
  }

  // removeFromOrderWC(item1:any){
  //   this.OrderNo1 = item1.OrderNo;
  //   this.service.deleteOrderItem(this.OrderNo1).subscribe(data=>{
  //     console.log(data.toString());
  //     this.refreshBillList();
  //   });

  // }

  // proceedBill(){
  //   this.OrderList.forEach((order:any) => {
  //     this.PartTotal = order.Price * order.Quantity;

  //     let orders = {
  //       UserId: this.CurrentUserId,
  //       FoodName: order.FoodName,
  //       Quantity:order.Quantity,

  //       Price: this.PartTotal
  //     }
  //     this.removeFromOrderWC(order);
  //   });
  //   this.router.navigate(['/Order']);
  //   this.refreshBillList();
  // }


}

