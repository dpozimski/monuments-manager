import { Component, OnInit } from '@angular/core';
import { UsersClient, UserDto, GetUsersQuery } from '../api/monuments-manager-api';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: [
    './users.component.css',
    './../styles/cards.css'
  ]
})
export class UsersComponent implements OnInit {

  users: UserDto[];

  constructor(private usersClient: UsersClient) { }

  ngOnInit() {
    this.fillUsersCollection();
  }

  private fillUsersCollection() {
    var query = new GetUsersQuery();

    this.usersClient.getAll(query)
      .subscribe(s => this.users = s);
  }
}
