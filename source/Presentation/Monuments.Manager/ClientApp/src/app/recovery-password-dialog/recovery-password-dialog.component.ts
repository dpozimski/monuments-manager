import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { RecoveryClient, SendRecoveryKeyCommand } from '../api/monuments-manager-api';

@Component({
  selector: 'app-recovery-password-dialog',
  templateUrl: './recovery-password-dialog.component.html',
  styleUrls: [
    './recovery-password-dialog.component.css',
    './../styles/forms.css'
  ]
})
export class RecoveryPasswordDialogComponent extends DialogComponent<any, boolean> {
  serverError: boolean;
  recoveryEmail: string;
  submitted: boolean;

  constructor(dialogService: DialogService,
              private recoveryClient: RecoveryClient) {
    super(dialogService);
  }

  confirm() {
    this.submitted = true;

    var request = new SendRecoveryKeyCommand();
    request.email = this.recoveryEmail;

    this.recoveryClient.sendRecoveryKey(request)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleErrorResult());
  }

  handleErrorResult() {
    this.submitted = false;
    this.serverError = true;
  }
  
  handleSuccessResult() {
    this.close();
  }
}
