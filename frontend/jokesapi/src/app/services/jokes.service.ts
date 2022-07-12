import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JokesService {

  constructor(private httpClient: HttpClient) {
  }

  dailyJoke() {
    const dailyJokesEndpoint = '/api/v1/jokes/daily'
    //const options = {responseType: "text"}

    if (environment.production) {
      return this.httpClient.get(dailyJokesEndpoint, {responseType: "text"});
    } else if (environment.development) {
      return this.httpClient.get(environment.devURL + dailyJokesEndpoint, {responseType: "text"});
    }

    return of("Bad Jokes Only!")
  }

  getRandomJoke() {
    const dailyJokesEndpoint = '/api/v1/jokes/daily'
    //const options = {responseType: "text"}

    if (environment.production) {
      return this.httpClient.get(dailyJokesEndpoint, {responseType: "text"});
    } else if (environment.development) {
      return this.httpClient.get(environment.devURL + dailyJokesEndpoint, {responseType: "text"});
    }

    return of("Bad Jokes Only!")
  }

  getJoke(id: number) {
    const jokesEndpoint = '/api/v1/jokes'
    //const options = {responseType: "text"}

    if (environment.production) {
      return this.httpClient.get(jokesEndpoint, {responseType: "text"});
    } else if (environment.development) {
      return this.httpClient.get(environment.devURL + jokesEndpoint, {responseType: "text"});
    }

    return of("Random Bad Joke!")
  }

  addJoke(joke: string) {
    const jokesEndpoint = '/api/v1/jokes'
    //const options = {responseType: "text"}

    const sqlSelect = ";SELECT";
    const sqlUpdate = ";UPDATE";
    const sqlDelete = ";DELETE";
    const sqlDrop = ";DROP";
    const sqlTrunc = ";TRUNCATE";
    const sqlComment = "--";

    const jokeCheck = joke.toUpperCase().replace(/\s/g, "");

    if (jokeCheck.includes(sqlSelect)) {
      return console.error("Suspicious sql select format");
    }
    if (jokeCheck.includes(sqlUpdate)) {
      return console.error("Suspicious sql update format");
    }
    if (jokeCheck.includes(sqlDelete)) {
      return console.error("Suspicious sql delete format");
    }
    if (jokeCheck.includes(sqlDrop)) {
      return console.error("Suspicious sql drop format");
    }
    if (jokeCheck.includes(sqlTrunc)) {
      return console.error("Suspicious sql truncate format");
    }
    if (jokeCheck.includes(sqlComment)) {
      return console.error("Suspicious sql comment format");
    }

    if (environment.production) {
      return this.httpClient.post(jokesEndpoint, {joke: joke});
    } else if (environment.development) {
      return this.httpClient.post(environment.devURL + jokesEndpoint, {joke: joke});
    }

    return of("Success")
  }
}

export class Joke {
  Id: number = 0
  Content: string = ""
  Mature: boolean = false
}

export class JokeMachine {
  public currentJoke: string = ""

  private jokeObserve = {
    next: (joke: string) => {
      this.currentJoke = joke;
    },
    error: (err: Error) => {
      //401 403
      console.error(err);
    },
    complete: () => {}
  }

  constructor(private jokeService: JokesService) {
  }

  setDaily() {
    this.jokeService.dailyJoke().subscribe(this.jokeObserve)
  }

  setNewJoke(id: number) {
    this.jokeService.getJoke(id).subscribe(this.jokeObserve)
  }

  setRandomJoke() {
    this.jokeService.getJoke(-1).subscribe(this.jokeObserve)
  }
}
