import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CookieModule } from 'ngx-cookie';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { SessionComponent } from './pages/session/session.component';

import { AddJokeComponent } from './components/add-joke/add-joke.component';
import { GetJokeComponent } from './components/get-joke/get-joke.component';
import { HttpClientModule } from '@angular/common/http';
import { FofComponent } from './pages/fof/fof.component';
import { CookieGuard } from './guards/cookie.guard';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    SessionComponent,
    AddJokeComponent,
    GetJokeComponent,
    FofComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, //this cost 2.5 hours :(
    CookieModule.withOptions(),
    BrowserAnimationsModule,
  ],
  providers: [CookieGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }