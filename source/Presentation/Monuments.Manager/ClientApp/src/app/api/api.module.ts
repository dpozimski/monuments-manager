import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import { Configuration } from './configuration';
import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';


import { UsersClient } from './monuments-manager-api';
import { DictionariesClient } from './monuments-manager-api';
import { MonumentsClient } from './monuments-manager-api';
import { PicturesClient } from './monuments-manager-api';
import { JwtInterceptor } from './security/jwt.interceptor';
import { ErrorInterceptor } from './security/error.interceptor';

@NgModule({
    imports: [],
    declarations: [],
    exports: [],
    providers: [
        UsersClient,
        DictionariesClient,
        MonumentsClient,
        PicturesClient,
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }    
    ]
})
export class ApiModule {
    public static forRoot(configurationFactory: () => Configuration): ModuleWithProviders {
        return {
            ngModule: ApiModule,
            providers: [{ provide: Configuration, useFactory: configurationFactory }]
        };
    }

    constructor(@Optional() @SkipSelf() parentModule: ApiModule,
        @Optional() http: HttpClient) {
        if (parentModule) {
            throw new Error('ApiModule is already loaded. Import in your base AppModule only.');
        }
        if (!http) {
            throw new Error('You need to import the HttpClientModule in your AppModule! \n' +
                'See also https://github.com/angular/angular/issues/20575');
        }
    }
}