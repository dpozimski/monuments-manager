import { Component, OnInit } from '@angular/core';
import { UsersClient, UserDto } from '../api/monuments-manager-api';

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

  }

  private fillUsersCollection() {
    this.usersClient.get()
  }
}
