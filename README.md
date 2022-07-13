# Joke-Of-The-Day

This repo contains the Frontend (written in Angular) and the backend (written in C#)
with the db scripts included.

## Prerequisites
Node.js which includes Node Package Manager.

## Frontend
The frontend setup for local building and running requires Anguler CLI to be installed.

Install globally using

```
npm install -g @angular/cli
```

To run a development server use `ng serve` command in the terminal when in the "\frontend\jokesapi" directory. Navigate to `http://localhost:4200/` to test the local development server.

The modules should install automatically.

## Website
The typical flow of the webpages are:

Home -> Login (cognito) -> Dashboard
Logout (cognito) -> Loggedout -> Home
404 -> Home

The daily joke is displayed on the Home page. When logged in, a random joke can be gotten through button press or the joke of the day can be retrieved again. 
When logged in as an administrator a new joke can be added in the text box.