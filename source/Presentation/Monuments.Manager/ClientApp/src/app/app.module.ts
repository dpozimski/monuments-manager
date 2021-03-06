import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { ToastrModule } from 'ngx-toastr';
import { ApiModule } from './api/api.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxGalleryModule } from 'ngx-gallery';
import { FileHelpersModule } from 'ngx-file-helpers';
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
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './api/security/auth.guard';
import { RecoveryPasswordDialogComponent } from './recovery-password/recovery-password-dialog/recovery-password-dialog.component';
import { RecoveryPasswordComponent } from './recovery-password/master/recovery-password.component';
import { MonumentsComponent } from './monuments/master/monuments.component';
import { UsersComponent } from './users/master/users.component';
import { UsersListComponent } from './users/users-list/users-list.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UsersActionsComponent } from './users/users-actions/users-actions.component';
import { PromoteUserDialogComponent } from './users/promote-user-dialog/promote-user-dialog.component';
import { UserConfirmationDialogComponent } from "./layout/user-confirmation-dialog/user-confirmation-dialog.component";
import { EditUserDialogComponent } from './users/edit-user-dialog/edit-user-dialog.component';
import { MonumentsListComponent } from './monuments/monuments-list/monuments-list.component';
import { MonumentsHeaderComponent } from './monuments/monuments-header/monuments-header.component';
import { MonumentsListDetailComponent } from './monuments/monuments-list-detail/monuments-list-detail.component';
import { MonumentsPicturesGalleryComponent } from './monuments/monuments-pictures-gallery/monuments-pictures-gallery.component';
import { MonumentsDetailFormComponent } from './monuments/monuments-detail-form/monuments-detail-form.component';
import { CreatePictureDialogComponent } from './monuments/create-picture-dialog/create-picture-dialog.component';
import { CreateMonumentDialogComponent } from './monuments/create-monument-dialog/create-monument-dialog.component';
import { MonumentsDetailActionsComponent } from './monuments/monuments-detail-actions/monuments-detail-actions.component';
import { RecentComponent } from './recent/master/recent.component';
import { RecentHeaderComponent } from './recent/recent-header/recent-header.component';
import { RecentCardsComponent } from './recent/recent-cards/recent-cards.component';
import { RecentCardComponent } from './recent/recent-card/recent-card.component';
import { RecentCardDetailsDialogComponent } from './recent/recent-card-details-dialog/recent-card-details-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    RegisterComponent,
    RecoveryPasswordDialogComponent,
    RecoveryPasswordComponent,
    MonumentsComponent,
    UsersComponent,
    UsersListComponent,
    UserDetailComponent,
    UsersActionsComponent,
    PromoteUserDialogComponent,
    UserConfirmationDialogComponent,
    EditUserDialogComponent,
    MonumentsListComponent,
    MonumentsHeaderComponent,
    MonumentsListDetailComponent,
    MonumentsPicturesGalleryComponent,
    MonumentsDetailFormComponent,
    CreatePictureDialogComponent,
    CreateMonumentDialogComponent,
    MonumentsDetailActionsComponent,
    RecentComponent,
    RecentHeaderComponent,
    RecentCardsComponent,
    RecentCardComponent,
    RecentCardDetailsDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiModule,
    NgxGalleryModule,
    BootstrapModalModule,
    FileHelpersModule,
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
      { path: '', redirectTo: '/recent', pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'recent', component: RecentComponent, canActivate: [AuthGuard] },
      { path: 'monuments', component: MonumentsComponent, canActivate: [AuthGuard] },
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard] },
      { path: 'recovery-password', component: RecoveryPasswordComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
    ], {onSameUrlNavigation: 'reload'})
  ],
  entryComponents: [
    RecoveryPasswordDialogComponent,
    PromoteUserDialogComponent,
    UserConfirmationDialogComponent,
    EditUserDialogComponent,
    CreatePictureDialogComponent,
    CreateMonumentDialogComponent,
    RecentCardDetailsDialogComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
