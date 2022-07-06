import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from "@angular/router";
import { JokesService } from "src/app/services/jokes.service";
import { LoginService } from "src/app/services/login.service";

@Component({
  selector: 'page-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  private dailyJoke: string = "Joke Loading..."
  private jokeObserver = {
    next: (joke: string) => {
      this.dailyJoke = joke
    },
    error: (err: Error) => {
      console.error(err)
      this.dailyJoke = "The real joke is how broken this site is :D"
    },
    complete: () => {}
  }

  constructor(private jokesService: JokesService, private loginService: LoginService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.jokesService.dailyJoke().subscribe(this.jokeObserver)
  }

  gotoLogin(): void {
    this.loginService.gotoLogin();
  }

}
