import { Component } from '@angular/core';
import { DialogService, DialogComponent } from 'ng2-bootstrap-modal';
import { UserConfirmationParameters } from './user-confirmation-parameters';

@Component({
  selector: 'app-user-confirmation-dialog',
  templateUrl: './user-confirmation-dialog.component.html',
  styleUrls: [
    './user-confirmation-dialog.component.css',
    './../../styles/forms.css',
    './../../styles/cards.css'
  ]
})
export class UserConfirmationDialogComponent extends DialogComponent<UserConfirmationParameters, boolean> implements UserConfirmationParameters {
  title: string;
  message: string;
  isDanger: boolean;

  constructor(dialogService: DialogService) {
    super(dialogService);
  }

  confirm() {
    this.result = true;
    this.close();
  }
}