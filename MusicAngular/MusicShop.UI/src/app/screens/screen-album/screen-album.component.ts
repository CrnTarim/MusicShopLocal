import { Component } from '@angular/core';
import { Album } from 'src/app/models/music-shop';
import { MusicShopService } from 'src/app/services/music-shop.service';

@Component({
  selector: 'app-screen-album',
  templateUrl: './screen-album.component.html',
  styleUrls: ['./screen-album.component.css']
})
export class ScreenAlbumComponent {

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

