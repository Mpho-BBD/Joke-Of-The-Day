import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }

  validate() {
    const validateEndpoint = "/api/v1/validate"

    if (environment.production) {
      return this.httpClient.get(validateEndpoint, {responseType: "text"})
    } else if (environment.development) {
      return this.httpClient.get(environment.devURL + validateEndpoint, {responseType: "text"})
    }

    //cookies
    return of("OK")
  }

  gotoLogin() {
    const loginEndpoint = "/api/v1/login"

    if (environment.production) {
      //Problably router instead
      window.location.href = loginEndpoint
    } else if (environment.development) {
      window.location.href = environment.devURL + loginEndpoint
    }

    window.location.href = "https://jokesapi.auth.eu-west-1.amazoncognito.com/oauth2/authorize?client_id=632uqqj15rj2j2u3mhm38qook2&response_type=code&scope=email+jokesapi%2Fjoke.read+jokesapi%2Fjoke.write+openid&redirect_uri=http%3A%2F%2Flocalhost%3A4200%2Fsession"
  }
}
