import { Component, OnInit } from '@angular/core';
import { AppService } from '../shared/app.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { formatDate } from '@angular/common';
import { FlightScheduleModel } from '../models/FlightSchedule.model';

@Component({
  selector: 'app-new-flight',
  templateUrl: './new-flight.component.html',
  styleUrls: ['./new-flight.component.css']
})
export class NewFlightComponent implements OnInit {
  
  flightForm: FormGroup;
  flightId: string;

  constructor(
    private route: ActivatedRoute, 
    private formBuilder: FormBuilder,
    private router: Router,
    private api: AppService
  ) { }

  ngOnInit() {
    this.flightForm = this.formBuilder.group({
      id: [''],
      nome: ['', Validators.required],
      origem :['', Validators.required],
      destino: ['', Validators.required],
      dataHoraPartida: ['', Validators.required],
    });

    this.route.params.subscribe(params =>{
      this.flightId = params.id;
      if(this.flightId){
        this.api.getFlight(this.flightId)
        .subscribe(res => {
          this.flightForm = this.formBuilder.group({
            id: [res.id],
            nome: [res.nome],
            origem :[res.origem],
            destino: [res.destino],
            dataHoraPartida: [formatDate(res.dataHoraPartida, "yyyy-MM-ddThh:mm", 'en_US')],
          });
          console.log(res);
        }, err => {
          console.log(err);
        })
      }
    })
  }
  onSubmit(form: FlightScheduleModel){
      if(this.flightForm.valid){
        if(this.flightId){
          this.api.replaceFlight(form)
          .subscribe(res=>{
            this.router.navigate(['list-flights']);
          }, err =>{
            console.log(err);
          })
        }else{
          this.api.addFlight(form)
        .subscribe(res=>{
          console.log(res);
          this.router.navigate(['/list-flights']);
        }, (err) => {
          console.log(err);
        })
        }
      }
  }

}
