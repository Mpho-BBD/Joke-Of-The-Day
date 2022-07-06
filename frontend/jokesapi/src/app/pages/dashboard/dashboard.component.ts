import { Component, OnInit } from '@angular/core';
import { CookieService, UIHint } from 'src/app/services/cookie.service';

@Component({
  selector: 'page-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  uiHint: UIHint = new UIHint();

  constructor(private cookieService: CookieService) { }

  ngOnInit(): void {
    this.uiHint = this.cookieService.getUIHint()
  }

}
