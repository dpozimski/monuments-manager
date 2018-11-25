import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateUserViewModel } from '../api/monuments-manager-api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  private returnUrl: string;

  model: AuthenticateUserViewModel = new AuthenticateUserViewModel();

  submitted: boolean;
  severRejectedCredentials: boolean;

  constructor(private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) {
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

    this.authenticationService.login(this.model.username, this.model.password)
      .subscribe(result => this.handleSuccessResult(result),
                 error => this.handleFailResult(error));
  }

  private handleFailResult(error: any) {
    this.submitted = false;
    this.severRejectedCredentials = true;
  }

  private handleSuccessResult(result: Boolean) {
    this.router.navigate([this.returnUrl]);
  }
}
