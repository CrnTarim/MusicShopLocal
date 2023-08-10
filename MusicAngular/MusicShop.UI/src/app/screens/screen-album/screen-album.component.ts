import { Component } from '@angular/core';
import { Album } from 'src/app/models/music-shop';
import { MusicShopService } from 'src/app/services/music-shop.service';
import * as signalR from '@microsoft/signalr';

@Component({
  selector: 'app-screen-album',
  templateUrl: './screen-album.component.html',
  styleUrls: ['./screen-album.component.css']
})
export class ScreenAlbumComponent {

  title = 'MusicShop.UI';
  albums: Album[]=[];
  albumToEdit?: Album;

  constructor(private album : MusicShopService,private albumService : MusicShopService){}

  ngOnInit() : void{
    this.album.getAlbum().subscribe((result : Album[])=>(this.albums=result));

    const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7142/notify')
    .configureLogging(signalR.LogLevel.Information)
    .build();

    connection.start()
    .then(function () {
        console.log('SignalR Album Connected!');
    })
    .catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("BroadcastMessage", () => {  
      this.albumService.getAlbum();
    });  
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

