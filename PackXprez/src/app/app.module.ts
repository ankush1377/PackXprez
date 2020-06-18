import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ViewUsersComponent } from './view-users/view-users.component';
import { LoginComponent } from './login/login.component';
import { UserService } from '../packXprez-services/user-service/user.service';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { ScheduleShipmentComponent } from './schedule-shipment/schedule-shipment.component';
import { TrackPackageComponent } from './track-package/track-package.component';
import { PackageHistoryComponent } from './package-history/package-history.component';
import { CheckServiceAvailabilityComponent } from './check-service-availability/check-service-availability.component';
import { routing } from './app.routing';
import { CommonLayoutComponent } from './common-layout/common-layout.component';


@NgModule({
  declarations: [
    AppComponent,
    ViewUsersComponent,
    LoginComponent,
    HomeComponent,
    ScheduleShipmentComponent,
    TrackPackageComponent,
    PackageHistoryComponent,
    CheckServiceAvailabilityComponent,
    CommonLayoutComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    routing
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
