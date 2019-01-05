import { Component } from '@angular/core';
import { AuthenticationService } from '../../api/authentication.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { Router } from '@angular/router';
import { UserConfirmationDialogComponent } from '../user-confirmation-dialog/user-confirmation-dialog.component';
import { UserRoleDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authenticationService: AuthenticationService,
              private dialogService: DialogService,
              private router: Router) {
  }

  isCurrentUserAdministrator(): boolean {
    return this.authenticationService.getAuthenticationData().user.role === UserRoleDto.Administrator;
  }

  isUserLoggedIn(): boolean {
    return this.authenticationService.getAuthenticationData() != null;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.dialogService.addDialog(
        UserConfirmationDialogComponent,
        {title: 'Logout confirmation', message: 'Are you sure to sign out from the application?'
      })
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.authenticationService.logout();
          this.router.navigate(['/login']);
        }
      });
  }
}
