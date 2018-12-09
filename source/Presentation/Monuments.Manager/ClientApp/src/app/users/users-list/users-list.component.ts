import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { UserDto, UsersClient, DeleteUserCommand } from '../../api/monuments-manager-api';
import { UsersService } from '../users.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { UserConfirmationDialogComponent } from './../../layout/user-confirmation-dialog/user-confirmation-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { EditUserDialogComponent } from '../edit-user-dialog/edit-user-dialog.component';
import { EditUserParameters } from './../edit-user-dialog/edit-user-parameters';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: [
    './users-list.component.css',
    './../../styles/tables.css'
  ]
})
export class UsersListComponent implements OnInit {
  displayedColumns: string[] = [
    'firstName', 
    'lastName', 
    'email', 
    'jobTitle',
    'stats',
    'edit',
    'delete'
  ];
  dataSource: MatTableDataSource<UserDto>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private usersClient: UsersClient,
              private usersService: UsersService,
              private dialogService: DialogService,
              private toastr: ToastrService) {
    
  }

  ngOnInit() {
    this.fillUsers();
    this.usersService.refreshUsersChanged
        .subscribe(_ => this.fillUsers());
  }

  delete(element: UserDto) {
    this.dialogService.addDialog(
        UserConfirmationDialogComponent, 
        { 
          title: "Delete user", 
          message: "Are you sure to delete user with e-mail: " + element.email, 
          isDanger: true
        })
        .subscribe(accepted => {
          if(accepted) {
            var command = new DeleteUserCommand();
            command.id = element.id;
            this.usersClient.delete(command)
                .subscribe(_ => { 
                  this.toastr.success('User has been removed');
                  this.fillUsers();
                }, _ => this.toastr.error('User cannot be removed'));
          }
        })
  }

  edit(element: UserDto) {
    this.dialogService.addDialog(
        EditUserDialogComponent,
        { user: element }
        ).subscribe(result => {
          if(result) {
            this.fillUsers();
          }
        });
  }

  showStats(element: UserDto) {
    this.usersService.userStatsContextCommand(element);
  }

  private fillUsers() {
    var users: UserDto[] = [];
    this.setDataSource(users);

    this.usersClient.getAll()
        .subscribe(s => this.setDataSource(s));
  }

  private setDataSource(users: UserDto[]) {
    this.dataSource = new MatTableDataSource<UserDto>(users);
    this.dataSource.paginator = this.paginator;

    if(users.length > 0) {
      this.usersService.userStatsContextCommand(users[0]);
    }
  }
}
