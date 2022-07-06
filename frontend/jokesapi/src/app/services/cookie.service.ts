import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class CookieService {

  private _isValid: boolean = false;
  private _uiHint: UIHint = new UIHint();

  constructor(private loginService: LoginService) {
  }

  getUIHint() {
    if (environment.production) {
      //cookie etc
      return new UIHint();
    } else if (environment.development)  {
      //cookie etc
      return new UIHint();
    }

    return new UIHint(true, true);
  }

  getSession() {
    //cookie etc
    return
  }

  interceptError(err: Error) : boolean {
    //check 401 and 403
    if (true) {
      return true;
    }

    this._isValid = false;
    return false;
  }

  isValid() : boolean {
    const validateObserve = {
      next: () => {
        this._isValid = true;
        //cookie
        //this._uiHint = uih;
      },
      error: (err: Error) => {
        //TODO: check only the correct errors 401 or 403
        this._isValid = false;
        this._uiHint = new UIHint(false,false);
        console.error(err)
      },
      complete: () => {}
    }

    this.loginService.validate().subscribe(validateObserve)
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
