import { Injectable } from '@angular/core';
import CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class CryptoService {
  encrypt(text: string): string {
    return CryptoJS.SHA512(text).toString(CryptoJS.enc.Base64);
  }
}
