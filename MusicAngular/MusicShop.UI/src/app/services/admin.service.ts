import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, tap } from 'rxjs';
import { UserAutho } from '../models/admin';
import { environment } from 'src/environments/environment.prod';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
 
  private url1="UserAutho/register";
  private url2="UserAutho/login";

  constructor(private http: HttpClient,private router :Router){}

  public register(admin :UserAutho): Observable<any>{  
    return this.http.post<any>(`${environment.apiUrl}/${this.url1}`,admin,);
  }

  public login(admin :UserAutho): Observable<string>{  
    return this.http.post(`${environment.apiUrl}/${this.url2}`,admin,{responseType: 'text',}).pipe(
      tap((response: string) => {
        if (response.length > 20) {
          this.router.navigate(['/album']);
        }
      }));
  }

}
