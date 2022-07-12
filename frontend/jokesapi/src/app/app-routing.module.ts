import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from "./pages/home/home.component";
import { DashboardComponent } from "./pages/dashboard/dashboard.component";
import { SessionComponent } from "./pages/session/session.component";
import { FofComponent } from './pages/fof/fof.component';
import { CookieGuard } from './guards/cookie.guard';
import { LoggedoutComponent } from './pages/loggedout/loggedout.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'home'},
  {path: 'home', component: HomeComponent},
  {path: 'dashboard', component: DashboardComponent, canActivate: [CookieGuard]},
  {path: 'loggedout', component: LoggedoutComponent},
  {path: 'session', component: SessionComponent}, //remove on prod
  {path: '**', component: FofComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
