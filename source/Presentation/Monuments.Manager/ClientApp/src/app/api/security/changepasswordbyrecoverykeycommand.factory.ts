import { Injectable } from '@angular/core';
import CryptoJS from 'crypto-js';
import { ChangePasswordByRecoveryKeyCommand } from '../monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class ChangePasswordByRecoveryKeyFactory {
  create(recoveryKey: string, password: String): ChangePasswordByRecoveryKeyCommand {
    var auhtUserViewModel = new ChangePasswordByRecoveryKeyCommand();
    auhtUserViewModel.recoveryKey = recoveryKey;
    auhtUserViewModel.password = CryptoJS.SHA512(password).toString(CryptoJS.enc.Base64);

    return auhtUserViewModel;
  }
}
