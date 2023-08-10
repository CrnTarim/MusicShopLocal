import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Album } from 'src/app/models/music-shop';
import { MusicShopService } from 'src/app/services/music-shop.service';
import * as signalR from '@microsoft/signalr';


@Component({
  selector: 'app-edit-album',
  templateUrl: './edit-album.component.html',
  styleUrls: ['./edit-album.component.css']
})
export class EditAlbumComponent implements OnInit{

  @Input() album?: Album;
  @Output() albumsUpdated = new EventEmitter<Album[]>();

  constructor(private albumService : MusicShopService,private http: HttpClient){}

  ngOnInit():void{ 

    // const connection = new signalR.HubConnectionBuilder()
    // .withUrl('https://localhost:7142/notify')
    // .configureLogging(signalR.LogLevel.Information)
    // .build();

    // connection.start()
    // .then(function () {
    //     console.log('SignalR Album Connected!');
    // })
    // .catch(function (err) {
    //     return console.error(err.toString());
    // });

    // connection.on("BroadcastMessage", () => {  
    //   this.albumService.getAlbum();
    // });  
      
  }

  updateAlbum(album: Album){
    this.albumService.updateAlbum(album).subscribe((albums)=>this.albumsUpdated.emit(albums));
  }

  deleteAlbum(album: Album){
    this.albumService.deleteAlbum(album).subscribe((albums)=>this.albumsUpdated.emit(albums));
  }
  
  createAlbum(album: Album){
    this.albumService.createAlbum(album).subscribe((albums)=>this.albumsUpdated.emit(albums));
     
  }

}
