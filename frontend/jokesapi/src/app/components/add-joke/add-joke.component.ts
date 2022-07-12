import { Component, OnInit } from '@angular/core';
import { JokesService } from 'src/app/services/jokes.service';

@Component({
  selector: 'add-joke',
  templateUrl: './add-joke.component.html',
  styleUrls: ['./add-joke.component.css']
})
export class AddJokeComponent implements OnInit {

  constructor(private jokeService: JokesService) { }

  ngOnInit(): void {
  }

  submit() {
    const newJoke  = "";
    this.jokeService.addJoke(newJoke)
  }

}
