import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Router } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AppCookieService } from '../services/cookie.service';

@Injectable({
  providedIn: 'root'
})
export class CookieGuard implements CanActivate {
  constructor(private appCookieService: AppCookieService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      return this.appCookieService.validate().pipe(map((s: string) => s==='OK')).pipe(map(loggedin => {
        if (!loggedin) {
          console.log("Still Valid!")
          return this.router.parseUrl('/login')
        }

        return true;
      }));
  }

}
