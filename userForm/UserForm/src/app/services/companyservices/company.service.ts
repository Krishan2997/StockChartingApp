import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyDetail } from './comapny.module';
import { Stock } from './stock.module';


@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http : HttpClient) { }

  // stock[]=new Stock[];

  baseUrl='https://localhost:44340/api/Company';

  formData:CompanyDetail = new CompanyDetail();
  list : CompanyDetail[]=new Array();

  addStockPrice(arraylist:any[]){
    var stock:Stock=new Stock();

    // for(var i=0;i<arraylist.length;i++){
    //   stock[i].CompanyStockCode=arraylist[i]["Company Code"];
    //   stock[i].StockExchangeId=arraylist[i]["Stock Exchange"];
    //   stock[i].CurrentPrice=arraylist[i]["Price Per Share(in Rs)"];
    //   stock[i].Date=arraylist[i]["Date"];
    //   stock[i].Time=arraylist[i]["Time"];
    // }

    return this.http.post(`${this.baseUrl}addStocks`, arraylist);
  }

  
  postCompanyDetails(){
    return this.http.post(this.baseUrl,this.formData);

  }

  putCompanyDetails(){
    return this.http.put(`${this.baseUrl}/${this.formData.id}`,this.formData);

  }

  deleteCompanyDetails(id:number)
  {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  refreshList(){
    this.http.get(this.baseUrl)
      .toPromise()
      .then(res => this.list = res as CompanyDetail[]);
  }
}
