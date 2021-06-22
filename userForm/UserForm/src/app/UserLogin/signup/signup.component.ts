import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { LoginService } from '../../services/loginServices/login.service'

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  constructor(public loginservices: LoginService,
    private router: Router) {
  }

  onSubmit(form: NgForm) {
    this.loginservices.userSignUp().subscribe(
      res => {
        this.resetForm(form);
        alert("sigup success");
        this.router.navigateByUrl("login");
      },
      err => { console.log(err) }
    )
  }

  resetForm(form: NgForm) {
    form.form.reset();
  }

  ngOnInit(): void {
  }

}
