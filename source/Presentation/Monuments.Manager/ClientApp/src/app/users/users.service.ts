import { Injectable, EventEmitter, Output } from '@angular/core';
import { UserDto } from '../api/monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  refreshUsers = false;
  @Output() refreshUsersChanged: EventEmitter<boolean> = new EventEmitter();

  userStatsContext: UserDto;
  @Output() userStatsContextChanged: EventEmitter<UserDto> = new EventEmitter();

  refreshUsersCommand() {
    this.refreshUsers = !this.refreshUsers;
    this.refreshUsersChanged.emit(this.refreshUsers);
  }

  userStatsContextCommand(user: UserDto) {
    this.userStatsContext = user;
    this.userStatsContextChanged.emit(this.userStatsContext);
  }
}
