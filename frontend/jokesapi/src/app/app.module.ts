import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { JokeComponent } from './components/joke/joke.component';
import { SessionComponent } from './page/session/session.component';
import { AddJokeComponent } from './components/add-joke/add-joke.component';
import { GetJokeComponent } from './components/get-joke/get-joke.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    JokeComponent,
    SessionComponent,
    AddJokeComponent,
    GetJokeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
