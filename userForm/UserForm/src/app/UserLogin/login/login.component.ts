import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LogIn } from 'src/app/services/loginServices/login.module';

import { LoginService } from '../../services/loginServices/login.service';
import { Router } from '@angular/router';
import { Response } from '../../services/loginServices/user.module';
import { NavBarComponent } from 'src/app/basic/nav-bar/nav-bar.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login = new LogIn();
  correct: boolean = true;
  response: Response = new Response();
  userType:string='user';

  constructor(private loginService: LoginService,
    private router: Router) {
  }

  onFormSubmit(form: NgForm) {
    this.loginService.login(this.login).subscribe(
      res => {
        //Saving response
        this.response = res;


        //Cheking response code
        if (this.response.code == 1) {
          this.correct = true;
          localStorage.setItem('SessionUser', this.login.UserName);
          
          //Storing token
          localStorage.setItem("token", this.response.token);

          //Authentication
          LoginService.authentication=true;

          //Routing        
          this.router.navigate(['']);

          console.log(localStorage.getItem("SessionUser"));
        }
        else{
          this.correct = false;
          alert(this.response.token);
        }

        //Resetting from
        this.resetForm(form);
      },
      err => {
        //Alert of error
        alert("some errror occured while loggin in");

        //Authentication
        LoginService.authentication=true;

        //Logging the Error
        console.log(err.valueOf());

        //Routing to login page again
        this.router.navigate(['login']);
      }
    );
  }


  //Resetting the form
  resetForm(form: NgForm) {
    form.form.reset();
    this.login = new LogIn();
  }

  ngOnInit() {
    localStorage.setItem('SessionUser', this.login.UserName);
  }

}
