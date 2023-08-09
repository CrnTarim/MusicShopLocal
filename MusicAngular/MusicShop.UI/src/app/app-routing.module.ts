import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScreenAlbumComponent } from './screens/screen-album/screen-album.component';
import { ScreenCustomerComponent } from './screens/screen-customer/screen-customer.component';
import { ScreenRecordCompanyComponent } from './screens/screen-record-company/screen-record-company.component';
import { HomeComponent } from './screens/home/home.component';
import { ScreenAdminComponent } from './screens/screen-admin/screen-admin.component';


const routes: Routes = [
  { path: 'album', component: ScreenAlbumComponent },
  { path: 'customer', component: ScreenCustomerComponent },
  { path: 'record', component: ScreenRecordCompanyComponent },
  { path: 'login', component: ScreenAdminComponent },
  { path: "", component: HomeComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
