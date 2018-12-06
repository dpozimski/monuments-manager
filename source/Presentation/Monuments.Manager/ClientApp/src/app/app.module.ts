import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ToastrModule } from 'ngx-toastr';
import { ApiModule } from './api/api.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './api/security/auth.guard';
import { SettingsComponent } from './settings/settings.component';
import { LogoutDialogComponent } from './logout-dialog/logout-dialog.component';
import { RecoveryPasswordDialogComponent } from './recovery-password-dialog/recovery-password-dialog.component';
import { RecoveryPasswordComponent } from './recovery-password/recovery-password.component';
import { MonumentsComponent } from './monuments/monuments.component';
import { DictionariesComponent } from './dictionaries/dictionaries.component';
import { UsersComponent } from './users/users.component';
import { UsersListComponent } from './users-list/users-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    SettingsComponent,
    LogoutDialogComponent,
    RecoveryPasswordDialogComponent,
    RecoveryPasswordComponent,
    MonumentsComponent,
    DictionariesComponent,
    UsersComponent,
    UsersListComponent,
    UserDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiModule,
    BootstrapModalModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: '/home', pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'monuments', component: MonumentsComponent, canActivate: [AuthGuard] },
      { path: 'dictionaries', component: DictionariesComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
      { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
      { path: 'recovery-password', component: RecoveryPasswordComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ])
  ],
  entryComponents: [
    LogoutDialogComponent,
    RecoveryPasswordDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
