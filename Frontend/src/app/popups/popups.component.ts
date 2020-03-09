import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


export interface DialogData{
  id: string;
}

@Component({
  selector: 'app-popups',
  templateUrl: './popups.component.html',
  styleUrls: ['./popups.component.css']
})
export class PopupsComponent{
  id = "";
  constructor(
      public dialogRef: MatDialogRef<PopupsComponent>,
      @Inject(MAT_DIALOG_DATA) public data: DialogData,
  ){
      this.id = this.data.id;
  }
  deleteUserConfirmed(){
      this.dialogRef.close(this.id);
  }
  cancelar(){
      this.dialogRef.close();
  }
}
