import { Component } from '@angular/core';
import { Album } from './models/music-shop';
import { MusicShopService } from './services/music-shop.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MusicShop.UI';
  albums: Album[]=[];
  albumToEdit?: Album;

  constructor(private album : MusicShopService){}

  ngOnInit() : void{
    this.album.getAlbum().subscribe((result : Album[])=>(this.albums=result));
  }

  updateAlbumList(albums: Album[])
  {
   this.albums=albums;
  }

  initNewAlbum()
  {
    this.albumToEdit = new Album();
  }

  editAlbum(album : Album)
  {
    this.albumToEdit = album;
  }
  
}
