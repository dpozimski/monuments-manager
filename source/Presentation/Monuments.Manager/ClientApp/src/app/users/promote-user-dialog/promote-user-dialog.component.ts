import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { PromoteUserCommand, UsersClient } from '../../api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-promote-user-dialog',
  templateUrl: './promote-user-dialog.component.html',
  styleUrls: [
    './promote-user-dialog.component.css',
    './../../styles/forms.css',
    './../../styles/cards.css'
  ]
})
export class PromoteUserDialogComponent extends DialogComponent<any, boolean> {
  private readonly toastTitle = 'Promote user';

  submitted: boolean;
  severRejectedCommand: boolean;
  model: PromoteUserCommand = new PromoteUserCommand();

  constructor(dialogService: DialogService,
              private toastr: ToastrService,
              private usersClient: UsersClient,
              private usersService: UsersService){
    super(dialogService);
  }

  promote() {
    this.submitted = true;
    this.severRejectedCommand = false;

    this.usersClient.promote(this.model)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleFailResult());
  }

  private handleFailResult() {
    this.submitted = false;
    this.severRejectedCommand = true;
    this.toastr.error('User has not been promoted', this.toastTitle);
  }

  private handleSuccessResult() {
    this.toastr.success('User has been promoted', this.toastTitle);
    this.usersService.refreshUsersCommand();
  }
}
