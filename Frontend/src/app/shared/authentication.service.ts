import { Injectable } from '@angular/core';
import { Auth } from './Auth.model';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, tap, map } from 'rxjs/operators';
import { throwError, Observable, of } from 'rxjs';
import {MatSnackBar} from '@angular/material/snack-bar';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type' : 'application/json'})
};
/////////////URL DO KUBERNETES MUDA TODA HORA
const apiUrl = 'https://localhost:5001/api';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  currentUser = {};
  constructor(
    private http: HttpClient,
    public router: Router,
    public _snackBar: MatSnackBar
  ) { }

  login(user : Auth){
    console.log(user)
    return this.http.post<Auth>(`${apiUrl}/auth`, user, httpOptions).subscribe(
      (res : any) => {
        localStorage.setItem('access_token', res.token)
        this.router.navigate(['list-flights']);
      }, 
      err => {
        this.handleError(err);
      })
  }
  getToken(){
    return localStorage.getItem('access_token');
  }
  get isLoggedIn() : boolean{
    let authToken = localStorage.getItem('access_token')
    return (authToken !== null) ? true : false
  }
  goLogout(){
    let removeToken = localStorage.removeItem('access_token');
    if(removeToken == null){
      this.router.navigate(['login']);
    }
  }

  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error['tittle'];
    } else {
      // server-side error
      msg = error.error['tittle'];
    }
    this._snackBar.open(msg, "", {
      duration: 4000,
    })
    return throwError(msg);
  }


}
