import { Injectable } from '@angular/core';
import CryptoJS from 'crypto-js';
import { AuthenticateUserViewModel } from '../monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class AuthenticateUserViewModelFactory {
  create(email: string, password: String): AuthenticateUserViewModel {
    var auhtUserViewModel = new AuthenticateUserViewModel();
    auhtUserViewModel.email = email;
    auhtUserViewModel.password = CryptoJS.SHA512(password).toString(CryptoJS.enc.Base64);

    return auhtUserViewModel;
  }
}
