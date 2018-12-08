import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { UserDto, UsersClient } from '../../api/monuments-manager-api';
import { UsersService } from '../users.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { UserConfirmationDialogComponent } from './../../user-confirmation-dialog/user-confirmation-dialog.component';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
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
              private dialogService: DialogService) {
    
  }

  ngOnInit() {
    this.fillUsers();
    this.usersService.refreshUsersChange
        .subscribe(_ => this.fillUsers());
  }

  delete(element: UserDto) {
    this.dialogService.addDialog(
          UserConfirmationDialogComponent, 
          {title: "dupa", message: "dupa1", isDanger: true})
        .subscribe(s => {
          console.log(s);
          console.log(element);
        })

  }

  edit(element: UserDto) {

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
  }
}
