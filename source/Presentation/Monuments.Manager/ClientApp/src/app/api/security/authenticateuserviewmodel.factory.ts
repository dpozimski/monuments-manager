import { Injectable } from '@angular/core';
import CryptoJS from 'crypto-js';
import { AuthenticateUserViewModel } from '../monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateUserViewModelFactory {
  create(username: string, password: String): AuthenticateUserViewModel {
    var auhtUserViewModel = new AuthenticateUserViewModel();
    auhtUserViewModel.username = username;
    auhtUserViewModel.password = CryptoJS.SHA512(password).toString(CryptoJS.enc.Base64);

    return auhtUserViewModel;
  }
}
