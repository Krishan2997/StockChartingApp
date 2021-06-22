import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './UserLogin/login/login.component';
import { SignupComponent } from './UserLogin/signup/signup.component';
import { NavBarComponent } from './basic/nav-bar/nav-bar.component';
import { HomeComponent } from './UserLogin/home/home.component';

import { AuthGuard } from './auth.guard';
import { CompanyDetailsComponent } from './Company/company-details/company-details.component';
import { UploadComponent } from './Company/upload/upload.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'signup', component: SignupComponent },
    { path: 'company-details', component: CompanyDetailsComponent},
    { path: 'upload', component: UploadComponent}
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
export const routingComponents = [LoginComponent, SignupComponent, NavBarComponent];