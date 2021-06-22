import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { CompanyService } from 'src/app/services/companyservices/company.service';
import { CompanyDetail } from 'src/app/services/companyservices/comapny.module';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html',
  styleUrls: [
  ]
})
export class CompanyFormComponent implements OnInit {

  constructor(public service:CompanyService, private toaster:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if(this.service.formData.id==0)
      this.insertRecord(form);
    else
      this.updateRecord(form);
    
  }

  insertRecord(form:NgForm)
  {
    this.service.postCompanyDetails().subscribe(
      res=>{
        this.resetForm(form);
        this.service.refreshList();
        this.toaster.success("Submitted Successfully!","Company Detail Register")
      },
      err=>{console.log(err)}
    )  
  }


  updateRecord(form:NgForm)
  {
    this.service.putCompanyDetails().subscribe(
      res=>{
        this.resetForm(form);
        this.service.refreshList()
        this.toaster.info("Updated Successfully!","Company Detail Register")
      },
      err=>{console.log(err)}
    )
   
  }

  resetForm(form:NgForm)
  {
    form.form.reset();
    this.service.formData = new CompanyDetail();
  }


}
