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
  serverError: string;
  user: UserDto;
  newPassword: string;

  constructor(dialogService: DialogService,
              private toastr: ToastrService,
              private usersClient: UsersClient,
              private cryptoService: CryptoService) {
    //'User has been not updated. Please verify your changes.'
    super(dialogService);
  }

  confirm() {
    var command = new UpdateUserCommand();
    command.id = this.user.id;
    command.jobTitle = this.user.jobTitle;
    command.firstName = this.user.firstName;
    command.lastName = this.user.lastName;
    
    if(this.newPassword) {
      command.password = this.cryptoService.encrypt(this.newPassword);
    }
  }
}
