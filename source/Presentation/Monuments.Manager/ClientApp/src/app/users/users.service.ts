import { Injectable, EventEmitter, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  refreshUsersTrigger = false;

  @Output() refreshUsersChange: EventEmitter<boolean> = new EventEmitter();

  refreshUsers() {
    this.refreshUsersTrigger = !this.refreshUsersTrigger;
    this.refreshUsersChange.emit(this.refreshUsersTrigger);
  }
}
