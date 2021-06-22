import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HomeComponent } from './UserLogin/home/home.component';
import { UploadComponent } from './Company/upload/upload.component';
import { CompanyDetailsComponent } from './Company/company-details/company-details.component';
import { CompanyFormComponent } from './Company/company-form/company-form.component';

@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    HomeComponent,
    UploadComponent,
    CompanyDetailsComponent,
    CompanyFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot() // ToastrModule added
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }