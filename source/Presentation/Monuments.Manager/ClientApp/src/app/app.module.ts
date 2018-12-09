import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ToastrModule } from 'ngx-toastr';
import { ApiModule } from './api/api.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatTreeModule,
} from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './layout/nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './api/security/auth.guard';
import { SettingsComponent } from './settings/settings.component';
import { RecoveryPasswordDialogComponent } from './recovery-password/recovery-password-dialog/recovery-password-dialog.component';
import { RecoveryPasswordComponent } from './recovery-password/master/recovery-password.component';
import { MonumentsComponent } from './monuments/monuments.component';
import { UsersComponent } from './users/master/users.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UsersActionsComponent } from './users/users-actions/users-actions.component';
import { PromoteUserDialogComponent } from './users/promote-user-dialog/promote-user-dialog.component';
import { UserConfirmationDialogComponent } from "./layout/user-confirmation-dialog/user-confirmation-dialog.component";
import { EditUserDialogComponent } from './users/edit-user-dialog/edit-user-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    SettingsComponent,
    RecoveryPasswordDialogComponent,
    RecoveryPasswordComponent,
    MonumentsComponent,
    UsersComponent,
    UsersListComponent,
    UserDetailComponent,
    UsersActionsComponent,
    PromoteUserDialogComponent,
    UserConfirmationDialogComponent,
    EditUserDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiModule,
    BootstrapModalModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatGridListModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: '', redirectTo: '/home', pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'monuments', component: MonumentsComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
      { path: 'settings', component: SettingsComponent, canActivate: [AuthGuard] },
      { path: 'recovery-password', component: RecoveryPasswordComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ], {onSameUrlNavigation: 'reload'})
  ],
  entryComponents: [
    RecoveryPasswordDialogComponent,
    PromoteUserDialogComponent,
    UserConfirmationDialogComponent,
    EditUserDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
