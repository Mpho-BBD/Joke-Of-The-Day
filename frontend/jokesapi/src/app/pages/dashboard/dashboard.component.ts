import { Component, OnInit } from '@angular/core';
import { AppCookieService, UIHint } from 'src/app/services/cookie.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'page-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  uiHint: UIHint = new UIHint();

  constructor(private cookieService: AppCookieService, private loginService: LoginService) { }

  ngOnInit(): void {
    this.uiHint = this.cookieService.getUIHint()
  }

}
