import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';
import { Customer } from '../models/customer-shop';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private url="Customer";
  constructor(private http: HttpClient) { }

  public getCustomer(): Observable<Customer[]>{
   
    return this.http.get<Customer[]>(`${environment.apiUrl}/${this.url}`);
  }

  public updateCustomer(customer :Customer): Observable<Customer[]>{
   
    return this.http.put<Customer[]>(`${environment.apiUrl}/${this.url}`,customer);
  }

  public createCustomer(customer :Customer): Observable<Customer[]>{
   
    return this.http.post<Customer[]>(`${environment.apiUrl}/${this.url}`,customer);
  }

  public deleteCustomer(customer :Customer): Observable<Customer[]>{
   
    return this.http.delete<Customer[]>(`${environment.apiUrl}/${this.url}/${customer.id}`);
  }
}
