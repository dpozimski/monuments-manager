import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { UserDto, UsersClient } from '../../api/monuments-manager-api';
import { UsersService } from '../users.service';

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
              private usersService: UsersService) {
    
  }

  ngOnInit() {
    this.fillUsers();
    this.usersService.refreshUsersChange
        .subscribe(_ => this.fillUsers());
  }

  private fillUsers() {
    var users = new UserDto[0];
    this.setDataSource(users);

    this.usersClient.getAll()
        .subscribe(s => this.setDataSource(s));
  }

  private setDataSource(users: UserDto) {
    this.dataSource = new MatTableDataSource<UserDto>(users);
    this.dataSource.paginator = this.paginator;
  }
}
