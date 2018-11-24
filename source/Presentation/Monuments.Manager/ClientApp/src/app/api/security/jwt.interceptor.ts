import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from './../authentication.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let authData = this.authenticationService.getAuthenticationData();

        if (authData && authData.token) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${authData.token}`
                }
            });
        }

        return next.handle(request);
    }
}