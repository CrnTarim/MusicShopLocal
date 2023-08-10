import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Customer } from 'src/app/models/customer-shop';
import { CustomerService } from 'src/app/services/customer-service.service';
import { environment } from 'src/environments/environment.prod';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent {

  @Input() customer?: Customer;
  @Output() customersUpdated = new EventEmitter<Customer[]>();

  private url="Customer";

  constructor(private customerService : CustomerService ,private http: HttpClient){}

  ngOnInit():void{  

  }
  
  updateCustomer(customer: Customer){
    this.customerService.updateCustomer(customer).subscribe((customers)=>this.customersUpdated.emit(customers));
  }

  deleteCustomer(customer: Customer){
    this.customerService.deleteCustomer(customer).subscribe((customers)=>this.customersUpdated.emit(customers));
  }
  
  createCustomer(customer: Customer){
    this.customerService.createCustomer(customer).subscribe((customers)=>this.customersUpdated.emit(customers));
  }

}
