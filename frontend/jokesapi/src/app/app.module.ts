import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CookieModule } from 'ngx-cookie';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

import { AddJokeComponent } from './components/add-joke/add-joke.component';
import { GetJokeComponent } from './components/get-joke/get-joke.component';
import { HttpClientModule } from '@angular/common/http';
import { FofComponent } from './pages/fof/fof.component';
import { CookieGuard } from './guards/cookie.guard';
import { LoggedoutComponent } from './pages/loggedout/loggedout.component';
import { LoginButtonComponent } from './components/login-button/login-button.component';
import { LogoutButtonComponent } from './components/logout-button/logout-button.component';
import { HomeButtonComponent } from './components/home-button/home-button.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DashboardComponent,
    AddJokeComponent,
    GetJokeComponent,
    FofComponent,
    LoggedoutComponent,
    LoginButtonComponent,
    LogoutButtonComponent,
    HomeButtonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, //this cost 2.5 hours :(
    CookieModule.withOptions(),
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [CookieGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
