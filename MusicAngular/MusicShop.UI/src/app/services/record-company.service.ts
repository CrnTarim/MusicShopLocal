import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RecordCompany } from '../models/recordCompany-shop';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class RecordCompanyService {

  private url="RecordCompany";

  constructor(private http: HttpClient) { }

  public getRecordCompany(): Observable<RecordCompany[]>{
   
    return this.http.get<RecordCompany[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateRecordCompany(recordCompany :RecordCompany): Observable<RecordCompany[]>{
   
    return this.http.put<RecordCompany[]>(`${environment.apiUrl}/${this.url}`,recordCompany);
  }

  public createRecordCompany(recordCompany:RecordCompany): Observable<RecordCompany[]>{
   
    return this.http.post<RecordCompany[]>(`${environment.apiUrl}/${this.url}`,recordCompany);
  }

  public deleteRecordCompany(recordCompany:RecordCompany): Observable<RecordCompany[]>{
   
    return this.http.delete<RecordCompany[]>(`${environment.apiUrl}/${this.url}/${recordCompany.id}`);
  }
}
