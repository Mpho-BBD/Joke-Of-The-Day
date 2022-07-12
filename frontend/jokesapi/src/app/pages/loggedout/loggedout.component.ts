import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'page-loggedout',
  templateUrl: './loggedout.component.html',
  styleUrls: ['./loggedout.component.css']
})
export class LoggedoutComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  homeClick() {
    this.router.navigate(['./home'])
  }

}
