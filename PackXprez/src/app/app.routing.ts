import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ViewUsersComponent } from './view-users/view-users.component';
import { ScheduleShipmentComponent } from './schedule-shipment/schedule-shipment.component';
import { TrackPackageComponent } from './track-package/track-package.component';
import { PackageHistoryComponent } from './package-history/package-history.component';
import { CheckServiceAvailabilityComponent } from './check-service-availability/check-service-availability.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'viewUsers', component: ViewUsersComponent },
  { path: 'scheduleShipment', component: ScheduleShipmentComponent },
  { path: 'trackPackage', component: TrackPackageComponent },
  { path: 'packageHistory', component: PackageHistoryComponent },
  { path: 'checkServiceAvailability', component: CheckServiceAvailabilityComponent },
  { path: '**', component: HomeComponent }
];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
