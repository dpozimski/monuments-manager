import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { UserDto, UsersClient } from '../api/monuments-manager-api';

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
    'Edit',
    'Delete'
  ];
  dataSource: MatTableDataSource<UserDto>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private usersClient: UsersClient) {
    
  }

  ngOnInit() {
    this.fillUsers();
  }

  private fillUsers() {
    this.usersClient.getAll()
        .subscribe(s => {
          this.dataSource = new MatTableDataSource<UserDto>(s);
          this.dataSource.paginator = this.paginator;
        });
  }
}
