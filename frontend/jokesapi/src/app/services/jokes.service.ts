import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams, HttpStatusCode } from '@angular/common/http';
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

    if (environment.production) {
      return this.httpClient.get<JokeResponse>(dailyJokesEndpoint);
    } else if (environment.development) {
      return this.httpClient.get<JokeResponse>(environment.devURL + dailyJokesEndpoint);
    }

    return of(new JokeResponse("Bad Jokes Only!"))
  }

  getRandomJoke() {
    const dailyJokesEndpoint = '/api/v1/jokes'

    if (environment.production) {
      return this.httpClient.get<JokeResponse>(dailyJokesEndpoint);
    } else if (environment.development) {
      return this.httpClient.get<JokeResponse>(environment.devURL + dailyJokesEndpoint);
    }

    return of(new JokeResponse("Random Bad Joke!"))
  }

  addJoke(joke: JokeRequest) {
    //TODO: return consistent
    const jokesEndpoint = '/api/v1/jokes'

    const sqlSelect = ";SELECT";
    const sqlUpdate = ";UPDATE";
    const sqlDelete = ";DELETE";
    const sqlDrop = ";DROP";
    const sqlTrunc = ";TRUNCATE";
    const sqlComment = "--";

    const jokeCheck = joke.content.toUpperCase().replace(/\s/g, "");

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
      return this.httpClient.post(jokesEndpoint, joke);
    } else if (environment.development) {
      return this.httpClient.post(environment.devURL + jokesEndpoint, joke);
    }

    return of(new JokeResponse("Success"))
  }
}

export class JokeResponse {
  id: number = 0
  content: string = ""
  mature: boolean = false

  constructor(joke: string) {
    this.content = joke;
  }
}

export class JokeRequest {
  content: string = ""
  mature: boolean = false

  constructor(content: string, mature: boolean) {
    this.content = content,
    this.mature = mature
  }
}

export class JokeMachine {
  public currentJoke: string = ""

  private jokeObserve = {
    next: (joke: JokeResponse) => {
      this.currentJoke = joke.content;
    },
    error: (err: Error) => {
      //401 403
      if (err instanceof HttpErrorResponse) {
         switch (err.status) {
          case HttpStatusCode.NotFound:
            this.currentJoke = 'The only thing funny here is how broken this site is :D';
            break;

          case HttpStatusCode.Unauthorized:
          case HttpStatusCode.Forbidden:
            this.currentJoke = 'The only thing funny here is how few permissions you have'
            break;

          default:
            break;
         }
      }
      console.error(err);
    },
    complete: () => {}
  }

  constructor(private jokeService: JokesService) {
  }

  setDaily() {
    this.jokeService.dailyJoke().subscribe(this.jokeObserve)
  }

  setRandomJoke() {
    this.jokeService.getRandomJoke().subscribe(this.jokeObserve)
  }
}
