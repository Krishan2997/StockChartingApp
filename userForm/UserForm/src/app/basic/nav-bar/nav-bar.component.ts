import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthGuard } from 'src/app/auth.guard';
// import { Emitter } from 'src/app/emitters/emitters';
import { LoginService } from 'src/app/services/loginServices/login.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(public loginService: LoginService,
    private router: Router) { }


  logOut() {
    this.loginService.logout().subscribe(
      res => {
        if (res.code == 1) {
          //Storing token
          // this.loginService.httpOptions.headers = this.loginService.httpOptions.headers.
            // set('Authorization', '');

          //Authentication
          LoginService.authentication=false;

          localStorage.removeItem('UserSession');

          //Routing to login page
          this.router.navigate(['login']);
        }
        else{
          //view response
          // alert(res.code + "\n" + res.token);
        }
      },
      err => {
        //Alert of error
        alert("some errror occured while logout");

        //Authentication
        LoginService.authentication=true;

        //Logging the Error
        console.log(err.valueOf());
      }
    );
  }

  ngOnInit(): void {
    // Emitter.authEmitter.subscribe(
    //   (auth: boolean) => {
    //     this.authentication = auth;
    //   }
    // );
  }

}