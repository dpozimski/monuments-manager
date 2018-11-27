import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';

@Component({
  selector: 'app-logout-dialog',
  templateUrl: './logout-dialog.component.html',
  styleUrls: ['./logout-dialog.component.css']
})
export class LogoutDialogComponent extends DialogComponent<any, boolean> {

  constructor(dialogService: DialogService) {
    super(dialogService);
  }

  confirm() {
    this.result = true;
    this.close();
  }
}
