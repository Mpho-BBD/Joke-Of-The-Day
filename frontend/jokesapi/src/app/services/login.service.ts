import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  //TODO: but dev urls in env

  gotoLogin() {
    const loginEndpoint = "/login"

    console.log(environment)

    if (environment.production) {
      window.location.href = loginEndpoint
    } else if (environment.development) {
      window.location.href = environment.devURL + loginEndpoint
    } else {
      window.location.href = "https://jokesapi.auth.eu-west-1.amazoncognito.com/oauth2/authorize?client_id=632uqqj15rj2j2u3mhm38qook2&response_type=code&redirect_uri=http://localhost:4200"
    }
  }

  gotoLogout() {
    const logoutEndpoint = "/logout"

    if (environment.production) {
      window.location.href = logoutEndpoint
    } else if (environment.development) {
      window.location.href = environment.devURL + logoutEndpoint
    } else {
      window.location.href = "https://jokesapi.auth.eu-west-1.amazoncognito.com/logout?client_id=632uqqj15rj2j2u3mhm38qook2&logout_uri=http://localhost:4200/loggedout";
    }
  }
}
