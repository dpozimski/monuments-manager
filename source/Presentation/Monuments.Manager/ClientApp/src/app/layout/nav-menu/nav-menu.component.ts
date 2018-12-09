import { Component } from '@angular/core';
import { AuthenticationService } from '../../api/authentication.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { Router } from '@angular/router';
import { LogoutDialogComponent } from '../../logout-dialog/logout-dialog.component';

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

  isUserLoggedIn(): Boolean {
    return this.authenticationService.getAuthenticationData() != null;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.dialogService.addDialog(LogoutDialogComponent)
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.authenticationService.logout();
          this.router.navigate(['/login']);
        }
      });
  }
}
