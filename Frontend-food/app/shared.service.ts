import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44391/api";

  constructor(private http:HttpClient) { }

  //UserDetail Controller in Server
  login(value:any){
    return this.http.post(this.APIUrl+'/Login/authenticate', value);
  }

  addUser(value:any){
    return this.http.post(this.APIUrl+'/Login', value);
  }

  //FurnitureDetail Controller in Server
  getmenu():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Food');
  }

  //Cart Controller in Server
  getCart():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Cart');
  }

  getCartUserId(value:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Cart/');
  }

  addCart(value:any){
    return this.http.post(this.APIUrl+'/Cart', value);
  }

  deleteCartItem(value:number){
    return this.http.delete(this.APIUrl+'/Cart/'+value);
  }

  //BillingDetail Controller in Server
  getBillingDetail(value:any):Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Order/'+value);
  }

  addBillingDetail(value:any){
    return this.http.post(this.APIUrl+'/Order', value);
  }
  deleteBillItem(value:any)
  {
    return this.http.delete(this.APIUrl+'/Order/'+value);
  }
  // deleteOrderItem(value:any)
  // {
  //   return this.http.delete(this.APIUrl+'/Order/'+value)
  // }
}

