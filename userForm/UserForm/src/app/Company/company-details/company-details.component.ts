import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CompanyDetail } from 'src/app/services/companyservices/comapny.module';
import { CompanyService } from 'src/app/services/companyservices/company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: [
  ]
})
export class CompanyDetailsComponent implements OnInit {

  constructor(public service: CompanyService, public toastr:ToastrService ) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  
  populateForm(selectedRecord: CompanyDetail)
  {
     this.service.formData = Object.assign({},selectedRecord);
  }

  onDelete(id:number)
  {
    if(confirm("Are sure want to delete this record?"))
    {
      this.service.deleteCompanyDetails(id)
      .subscribe(
        res=>{
          this.toastr.error("Item Delted Successfully!","Company Detail Register")
          this.service.refreshList()
        },
        err=>{
          console.log(err);
        }
      )
    }
  }


}
