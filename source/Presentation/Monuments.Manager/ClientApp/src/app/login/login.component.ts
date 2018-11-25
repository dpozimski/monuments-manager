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

  constructor(private authenticationService: AuthenticationService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  onSubmit() {
    this.submitted = true;

    this.authenticationService.login(this.model.username, this.model.password)
      .subscribe(result => this.handleLoginResult(result));
  }

  private handleLoginResult(result: Boolean) {
    console.log(result);

    return;

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
