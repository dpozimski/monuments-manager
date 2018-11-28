import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateUserViewModel } from '../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { RecoveryPasswordDialogComponent } from '../recovery-password-dialog/recovery-password-dialog.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css',
    './../styles/forms.css'
  ]
})
export class LoginComponent implements OnInit {
  private returnUrl: string;

  model: AuthenticateUserViewModel = new AuthenticateUserViewModel();

  submitted: boolean;
  severRejectedCredentials: boolean;

  constructor(private authenticationService: AuthenticationService,
              private route: ActivatedRoute,
              private router: Router,
              private dialogService: DialogService) {
  }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.returnUrl = params["returnUrl"] || "/home";
      });
  }

  login() {
    this.submitted = true;
    this.severRejectedCredentials = false;

    this.authenticationService.login(this.model.email, this.model.password)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleFailResult());
  }

  recoveryPassword() {
    this.dialogService.addDialog(RecoveryPasswordDialogComponent).subscribe();
  }

  private handleFailResult() {
    this.submitted = false;
    this.severRejectedCredentials = true;
  }

  private handleSuccessResult() {
    this.router.navigate([this.returnUrl]);
  }
}
