import { Injectable, OnInit } from '@angular/core';
import { FlightScheduleModel } from '../models/FlightSchedule.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json',
    'Authorization' : `Bearer ${sessionStorage.getItem('access_token')}`
  })
};
/////////////URL DO KUBERNETES MUDA TODA HORA
const apiUrl = 'https://localhost:5001/api/flights';

@Injectable({
  providedIn: 'root'
})
export class AppService{

  
  constructor(
    private http: HttpClient, 
    private _snackBar: MatSnackBar
  ) { }

  getFlights(): Observable<FlightScheduleModel[]>{
    return this.http.get<FlightScheduleModel[]>(apiUrl, httpOptions)
      .pipe(
        tap(res => console.log('list')),
        catchError(this.handleError("Error", []))
      )
  }
  getFlight(id: string): Observable<FlightScheduleModel>{
    const url = `${apiUrl}/${id}`
    return this.http.get<FlightScheduleModel>(url, httpOptions).pipe(
      tap(_=> console.log(`id=${id}`)),
      catchError(this.handleError<FlightScheduleModel>(`Erro ao buscar ${id}`))
    )
  }
  addFlight(flight): Observable<FlightScheduleModel>{
    return this.http.post<FlightScheduleModel>(apiUrl, flight, httpOptions).pipe(
      tap((res: FlightScheduleModel) => console.log(`Flight Scheduled`)),
      catchError(this.handleError<FlightScheduleModel>('Error'))
    )
  }
  replaceFlight(flight): Observable<any>{
    return this.http.put(apiUrl, flight, httpOptions).pipe(
      tap(_=> console.log(`update flight`)),
      catchError(this.handleError<any>('Error'))
    )
  }
  deleteFlight(id: string) : Observable<FlightScheduleModel>{
    const url = `${apiUrl}/${id}`;
    return this.http.delete<FlightScheduleModel>(url, httpOptions).pipe(
      tap(_=> console.log(`Deleted`)),
      catchError(this.handleError<FlightScheduleModel>('Error'))
    )
  }
  private handleError<T>(operation, result?: T){
    return (error: any): Observable<T> => {
      this._snackBar.open(operation, error.status, {
        duration: 4000,
      })
      console.error(error);
      return of(result as T);
    }
  }
}
