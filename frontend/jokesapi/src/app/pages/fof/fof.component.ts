import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'app-fof',
  templateUrl: './fof.component.html',
  styleUrls: ['./fof.component.css']
})
export class FofComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  homeClick() {
    this.router.navigate(['./home'])
  }

}
