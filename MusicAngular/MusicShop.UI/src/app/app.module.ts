import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EditAlbumComponent } from './components/edit-album/edit-album.component';
import { FormsModule } from '@angular/forms';
import { EditCustomerComponent } from './components/edit-customer/edit-customer.component';
import { ScreenCustomerComponent } from './screens/screen-customer/screen-customer.component';
import { ScreenAlbumComponent } from './screens/screen-album/screen-album.component';
import { ScreenRecordCompanyComponent } from './screens/screen-record-company/screen-record-company.component';
import { EditRecordCompanyComponent } from './components/edit-record-company/edit-record-company.component';


@NgModule({
  declarations: [
    AppComponent,
    EditAlbumComponent,
    EditCustomerComponent,
    ScreenCustomerComponent,
    ScreenAlbumComponent,
    ScreenRecordCompanyComponent,
    EditRecordCompanyComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
