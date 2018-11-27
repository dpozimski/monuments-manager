import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';

@Component({
  selector: 'app-recovery-password-dialog',
  templateUrl: './recovery-password-dialog.component.html',
  styleUrls: ['./recovery-password-dialog.component.css']
})
export class RecoveryPasswordDialogComponent extends DialogComponent<any, boolean> {

  constructor(dialogService: DialogService) {
    super(dialogService);
  }

}
