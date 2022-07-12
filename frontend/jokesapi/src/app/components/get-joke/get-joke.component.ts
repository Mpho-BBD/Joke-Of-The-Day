import { Component, OnInit } from '@angular/core';
import { JokesService, JokeMachine } from 'src/app/services/jokes.service';

@Component({
  selector: 'get-joke',
  templateUrl: './get-joke.component.html',
  styleUrls: ['./get-joke.component.css']
})
export class GetJokeComponent implements OnInit {

  currentJoke: JokeMachine = new JokeMachine(this.jokeService)

  constructor(private jokeService: JokesService) { }

  ngOnInit(): void {
    this.currentJoke.currentJoke = "Click for Funny™"
  }

  jokeRandomClick() {
    this.currentJoke.setRandomJoke();
  }

  jokeDailyClick() {
    this.currentJoke.setDaily();
  }

}
