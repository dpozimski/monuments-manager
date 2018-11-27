import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { LogoutDialogComponent } from '../logout-dialog/logout-dialog.component';
import { Router } from '@angular/router';
import { RouteHistoryService } from '../services/route-history.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService,
              private dialogService: DialogService,
              private routeHistoryService: RouteHistoryService,
              private router: Router) { }

  ngOnInit() {
    this.dialogService.addDialog(LogoutDialogComponent)
      .subscribe((isConfirmed) => {
        if (isConfirmed) {
          this.authenticationService.logout();
          this.router.navigate(['/login']);
        }
        else {
          var previousUrl = this.routeHistoryService.getPreviousUrl();
          this.router.navigate([previousUrl]);
        }
      });
  }
}
