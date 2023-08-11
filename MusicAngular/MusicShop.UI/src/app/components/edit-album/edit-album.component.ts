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

  nameExceedsLimit = false;
  singerExceedsLimit = false;
  recordCompanyExceedsLimit = false;

  constructor(private albumService : MusicShopService,private http: HttpClient){}

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

  checkCharacterLimit(value: string, maxLength: number, field: string) {
    switch (field) {
        case 'name':
            this.nameExceedsLimit = value.length > maxLength;
            break;
        case 'singer':
            this.singerExceedsLimit = value.length > maxLength;
            break;
        case 'recordCompanyName':
            this.recordCompanyExceedsLimit = value.length > maxLength;
            break;
        default:
            break;
    }
 }

onCustomerIdInput(event: any) {
  const input = event.target;
  const value = input.value;

  if (!/^\d*$/.test(value)) {
      input.value = value.slice(0, -1);
    }
 }
 
}
