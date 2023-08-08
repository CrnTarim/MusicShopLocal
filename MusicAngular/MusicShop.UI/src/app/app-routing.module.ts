import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ScreenAlbumComponent } from './screens/screen-album/screen-album.component';

const routes: Routes = [{path:"", component: ScreenAlbumComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
