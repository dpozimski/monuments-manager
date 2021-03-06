import { Component } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { EditUserParameters } from './edit-user-parameters';
import { UserDto, UsersClient, UpdateUserCommand } from './../../api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';
import { CryptoService } from './../../api/security/crypto.service';

@Component({
  selector: 'app-edit-user-dialog',
  templateUrl: './edit-user-dialog.component.html',
  styleUrls: [
    './edit-user-dialog.component.css',
    './../../styles/forms.css',
    './../../styles/cards.css'
  ]
})
export class EditUserDialogComponent extends DialogComponent<EditUserParameters, boolean> implements EditUserParameters {
  readonly dialogTitle = 'Edit user';
  submitted: boolean;
  serverError: string;
  user: UserDto;
  newPassword: string;

  constructor(dialogService: DialogService,
              private toastr: ToastrService,
              private usersClient: UsersClient,
              private cryptoService: CryptoService) {
    super(dialogService);
  }

  confirm() {
    this.submitted = true;
    this.serverError = null;

    var command = new UpdateUserCommand();
    command.id = this.user.id;
    command.jobTitle = this.user.jobTitle;
    command.firstName = this.user.firstName;
    command.lastName = this.user.lastName;
    
    if(this.newPassword) {
      command.password = this.cryptoService.encrypt(this.newPassword);
    }

    this.usersClient.update(command)
        .subscribe(_ => this.handleSuccessResult(), 
                   _ => this.handleErrorResult());
  }

  private handleErrorResult() {
    this.serverError = 'User has been not updated. Please verify your changes.';
    this.toastr.error(this.serverError, this.dialogTitle);
    this.submitted = false;
  }

  private handleSuccessResult() {
    this.toastr.success('User has been updated', this.dialogTitle);
    this.result = true;
    this.close();
  }
}
