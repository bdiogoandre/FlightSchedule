import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginScreenComponent } from './login-screen/login-screen.component';
import { NewFlightComponent } from './new-flight/new-flight.component';
import { ListFlightsComponent } from './list-flights/list-flights.component';
import { AuthGuard } from './shared/auth.guard';

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginScreenComponent},
  {path: 'new-flight', component : NewFlightComponent, canActivate: [AuthGuard]},
  {path: 'update-flight/:id', component : NewFlightComponent, canActivate: [AuthGuard]},
  {path: 'list-flights', component : ListFlightsComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
