import { Component, OnInit } from '@angular/core';
import { FlightScheduleModel } from '../models/FlightSchedule.model';
import { AppService } from '../shared/app.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { PopupsComponent } from '../popups/popups.component';

@Component({
  selector: 'app-list-flights',
  templateUrl: './list-flights.component.html',
  styleUrls: ['./list-flights.component.css']
})
export class ListFlightsComponent implements OnInit {
  displayedColumns;
  flightData: FlightScheduleModel[];
  isLoading = false;

  constructor(
    private _api: AppService, 
    public dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) { }

  ngOnInit() {
    this.displayedColumns = ['nome', 'origem', 'destino', 'dataHoraPartida', 'delete'];
    this.isLoading = true;
    this._api.getFlights()
    .subscribe(res => {
      this.flightData = res;
      console.log(this.flightData);
      this.isLoading = false;
    }, err =>{
      this._snackBar.open("Error while listing flights");
    })
  }
  delete(id){
    const dialogRef = this.dialog.open(PopupsComponent, {
      data: {id: id}
    });
    dialogRef.afterClosed().subscribe(result =>{
      if(result){
        this._api.deleteFlight(id).subscribe(res=>{
          this._snackBar.open("Excluído com sucesso!", "Excluir", {
            duration: 2000,
          });
          this.atualizaLista();
        }, (err)=>{
          console.log(err);
        })
      }
    })
  }
  
  atualizaLista() {
    this._api.getFlights()
    .subscribe(res => {
      this.flightData = res;
      this.isLoading = false;
    }, err => {
      console.log(err);
    })
  }

}
