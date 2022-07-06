import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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
}
