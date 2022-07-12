//USED BACKENDLESS LOCAL DEBUG
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.css']
})
export class SessionComponent implements OnInit {

  authToken: string | null = "";

  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.authToken = this.route.snapshot.paramMap.get("code")
    this.router.navigate(['./dashboard'])
  }

}
