import { Component, OnInit } from '@angular/core';
import { DialogComponent } from 'ng2-bootstrap-modal';
import { MonumentDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-create-monument-dialog',
  templateUrl: './create-monument-dialog.component.html',
  styleUrls: ['./create-monument-dialog.component.css']
})
export class CreateMonumentDialogComponent extends DialogComponent<CreateMonumentDialogComponent, MonumentDto> implements OnInit {
  monument: MonumentDto;

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new MonumentDto();
  }
}
