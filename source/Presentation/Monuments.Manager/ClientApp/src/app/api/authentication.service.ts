import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserDto, AuthenticateUserViewModel, AuthenticateUserResultViewModel, UsersClient } from './monuments-manager-api';
import { map } from 'rxjs/operators';
import { AuthenticateUserViewModelFactory } from './security/authenticateuserviewmodel.factory';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private readonly authDataKey: string = 'authData';

  private authDataSubject: BehaviorSubject<AuthenticateUserResultViewModel>;

  currentUser: Observable<UserDto>;

  constructor(private usersClient: UsersClient,
              private authUserViewModelFactory: AuthenticateUserViewModelFactory) {
    var authData = localStorage.getItem(this.authDataKey);
    this.authDataSubject = new BehaviorSubject<AuthenticateUserResultViewModel>(JSON.parse(authData));
    this.currentUser = this.authDataSubject.asObservable().pipe(map(result => result.user));
  }

  getAuthenticationData() : AuthenticateUserResultViewModel {
    var authDataValue = this.authDataSubject.value;
    return authDataValue;
  }

  login(username: string, password: string): Observable<Boolean> {
    var viewModel = this.authUserViewModelFactory.create(username, password);
    
    return this.usersClient.authenticate(viewModel)
      .pipe(map(result => {
        if (result && result.token) {
          localStorage.setItem(this.authDataKey, JSON.stringify(result));
          this.authDataSubject.next(result);
        }

        return result != null;
      }));
  }

  logout() {
    localStorage.removeItem(this.authDataKey);
    this.authDataSubject.next(null);
  }
}
