import { Injectable } from '@angular/core';
import { Album } from '../models/music-shop';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';


@Injectable({
  providedIn: 'root'
})
export class MusicShopService {
 
 private url="Album";

  constructor(private http: HttpClient) { }

  public getAlbum(): Observable<Album[]>{
   
    return this.http.get<Album[]>(`${environment.apiUrl}/${this.url}`);
    
  }

  public updateAlbum(album :Album): Observable<Album[]>{
   
    return this.http.put<Album[]>(`${environment.apiUrl}/${this.url}`,album);
  }

  public createAlbum(album :Album): Observable<Album[]>{
   
    return this.http.post<Album[]>(`${environment.apiUrl}/${this.url}`,album);
  }

  public deleteAlbum(album :Album): Observable<Album[]>{
   
    return this.http.delete<Album[]>(`${environment.apiUrl}/${this.url}/${album.id}`);
  }
}
