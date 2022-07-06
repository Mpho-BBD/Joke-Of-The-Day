//USED BACKENDLESS LOCAL DEBUG
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.css']
})
export class SessionComponent implements OnInit {

  private authToken: string | null = "";

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.authToken = this.route.snapshot.paramMap.get("code")
  }

}
