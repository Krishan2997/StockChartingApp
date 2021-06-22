import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LogIn } from './login.module';
import { User, Response } from './user.module';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) {

  }

  tokenParser = '';

  user: User = new User();

  loggedInUser=new LogIn();
  static authentication:boolean=!!localStorage.getItem("SessionUser");

  baseURL = 'https://localhost:44320';

  login(userLogin: LogIn): Observable<Response> {
    this.loggedInUser.UserName=userLogin.UserName;
    return this.http.post<Response>(`${this.baseURL}/usrlogin`, userLogin
      // , { headers: this.httpOptions.headers }
    );
  }

  logout() :Observable<Response> {
    let user=(localStorage.getItem("SessionUser"));
    var httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        Authorization: `Bearer ${localStorage.getItem("token")}`
      })
    };
  
    
    alert(httpOptions.headers);
    return this.http.post<Response>(`${this.baseURL}/logout`, {userName:user}
      , { headers: httpOptions.headers }
    );
  }

  userSignUp() {
    console.log(this.user);
    return this.http.post(`${this.baseURL}/signup`, this.user
      , { responseType: 'json' }
    );
  }

  gettoken(){
    return !!localStorage.getItem("SessionUser");
  }

  getAuth(){
    return LoginService.authentication;
  }

}

