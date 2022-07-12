import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from './login.service';
import { CookieService } from 'ngx-cookie';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppCookieService {

  private uiC = "ui-cookie"
  private sC = "session-cookie"

  constructor(private loginService: LoginService, private cookieService: CookieService, private httpClient: HttpClient) {
  }

  getUIHint() {
    if (environment.production) {
      const uiCookie = this.cookieService.get(this.uiC)
      if (uiCookie) {
        const uiH = JSON.parse(uiCookie);
        return (uiH as UIHint);
      }
      return new UIHint();
    }

    return new UIHint(true, true);
  }

  getSession(): string {
    return this.cookieService.get(this.sC) || ""
  }

  validate() {
    const validateEndpoint = "/api/v1/validate"

    if (environment.production) {
      return this.httpClient.get(validateEndpoint, {responseType: "text"})
    } else if (environment.development) {
      return this.httpClient.get(environment.devURL + validateEndpoint, {responseType: "text"})
    }

    return of("OK");
  }
}

export class UIHint {
  isAdmin: boolean = false
  isMature: boolean = false

  constructor(isAdmin: boolean = false, isMature: boolean = false) {
    this.isAdmin = isAdmin;
    this.isMature = isMature;
  }
}
