import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { JokesService, JokeMachine } from "src/app/services/jokes.service";

@Component({
  selector: 'page-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private jokesService: JokesService, private router: Router, private route: ActivatedRoute) { }

  dailyJoke: JokeMachine = new JokeMachine(this.jokesService);

  ngOnInit(): void {
    this.dailyJoke.setDaily();
  }

}
