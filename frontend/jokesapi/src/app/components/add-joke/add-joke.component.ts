import { Component, OnInit, NgModule } from '@angular/core';
import { JokesService } from 'src/app/services/jokes.service';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'add-joke',
  templateUrl: './add-joke.component.html',
  styleUrls: ['./add-joke.component.css']
})
export class AddJokeComponent implements OnInit {

  addJokeForm = this.formBuilder.group({
    joke: ''
  });

  public isMature: boolean;

  constructor(private jokeService: JokesService, private formBuilder: FormBuilder, ) { this.isMature = false }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const newJoke  = this.addJokeForm.value.joke;
    console.log('Form object: ', this.addJokeForm.value);
    console.log('Mature: ', this.isMature);
    this.jokeService.addJoke(newJoke!);
    this.addJokeForm.reset();
  }

}
