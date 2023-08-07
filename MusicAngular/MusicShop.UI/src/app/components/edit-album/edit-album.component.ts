import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Album } from 'src/app/models/music-shop';
import { MusicShopService } from 'src/app/services/music-shop.service';

@Component({
  selector: 'app-edit-album',
  templateUrl: './edit-album.component.html',
  styleUrls: ['./edit-album.component.css']
})
export class EditAlbumComponent implements OnInit{

  @Input() album?: Album;
  @Output() albumsUpdated = new EventEmitter<Album[]>();

  constructor(private albumService : MusicShopService){}

  ngOnInit():void{   
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
