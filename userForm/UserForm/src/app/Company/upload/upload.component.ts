import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CompanyService } from 'src/app/services/companyservices/company.service';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  constructor(private companyservices: CompanyService, private router: Router) { }

  title = "xlsread";
  file: any
  arrayBuffer: any
  filelist: any
  jsonData:any

  addfile(event: any) {
    this.file = event.target.files[0];
    let fileReader = new FileReader();
    fileReader.readAsArrayBuffer(this.file);
    fileReader.onload = () => {
      this.arrayBuffer = fileReader.result;
      var data = new Uint8Array(this.arrayBuffer);
      var arr = new Array();
      for (var i = 0; i < data.length; ++i) { arr[i] = String.fromCharCode(data[i]); }
      var bstr = arr.join("");
      var workbook = XLSX.read(bstr, { type: "binary" });
      var first_sheet_name = workbook.SheetNames[0];
      var worksheet = workbook.Sheets[first_sheet_name];
      // console.log(XLSX.utils.sheet_to_json(worksheet, { raw: true }));
      this.jsonData = XLSX.utils.sheet_to_json(worksheet, { raw: true });
      // this.jsonData=JSON.stringify(this.jsonData);
      const alpha: Blob = new Blob([this.jsonData], { type: "application/json" });
      
      // this.data.showdata(this.jsonData);
      /*
      this.companyservices.addStockPrice(this.jsonData).subscribe(
        res => {
          alert("success");
        },
        err => {
          // alert("error occured");
        }
      );
      */
    //  this.router.navigateByUrl("data");
      console.log(this.jsonData);
      this.filelist = [];
      
    }
  }

  onFileChange(event: any) {
    /* wire up file reader */
    const target: DataTransfer = <DataTransfer>(event.target);
    if (target.files.length !== 1) {
      throw new Error('Cannot use multiple files');
    }
    const reader: FileReader = new FileReader();
    reader.readAsBinaryString(target.files[0]);
    reader.onload = (e: any) => {
      /* create workbook */
      const binarystr: string = e.target.result;
      const wb: XLSX.WorkBook = XLSX.read(binarystr, { type: 'binary' });

      /* selected the first sheet */
      const wsname: string = wb.SheetNames[0];
      const ws: XLSX.WorkSheet = wb.Sheets[wsname];

      /* save data */
      const data = XLSX.utils.sheet_to_json(ws); // to get 2d array pass 2nd parameter as object {header: 1}
      console.log(data); // Data will be logged in array format containing objects
    };
  }

  ngOnInit(): void {
  }

}
