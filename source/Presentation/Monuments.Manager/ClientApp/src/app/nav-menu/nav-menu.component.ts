import { Component } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  private userService: UserService;

  isExpanded = false;

  constructor(userService: UserService) {
    this.userService = userService;
  }

  isUserLoggedIn(): Boolean {
    return this.userService.isLoggedIn;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
