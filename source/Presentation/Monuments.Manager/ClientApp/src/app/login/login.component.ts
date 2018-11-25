import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateUserViewModel } from '../api/monuments-manager-api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  model: AuthenticateUserViewModel = new AuthenticateUserViewModel();

  submitted: boolean;
  severRejectedCredentials: boolean;

  constructor(private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  login() {
    this.submitted = true;
    this.severRejectedCredentials = false;

    this.authenticationService.login(this.model.username, this.model.password)
      .subscribe(result => this.handleSuccessResult(result),
                 error => this.handleFailResult(error));
  }

  private handleFailResult(error: any) {
    this.submitted = false;
    this.severRejectedCredentials = true;
  }

  private handleSuccessResult(result: Boolean) {
    if (result) {
      var returnUrl = this.route.snapshot.queryParams["returnUrl"];

      if (returnUrl) {
        this.router.navigate(['/home']);
      } else {
        this.router.navigate([returnUrl]);
      }
    } else {
      this.submitted = false;
    }
  }
}
