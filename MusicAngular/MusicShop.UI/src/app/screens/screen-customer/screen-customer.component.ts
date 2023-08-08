import { Component } from '@angular/core';
import { Customer } from 'src/app/models/customer-shop';
import { CustomerService } from 'src/app/services/customer-service.service';

@Component({
  selector: 'app-screen-customer',
  templateUrl: './screen-customer.component.html',
  styleUrls: ['./screen-customer.component.css']
})
export class ScreenCustomerComponent {
  title = 'MusicShop.UI';
  customers: Customer[]=[];
  customerToEdit?: Customer;

  constructor(private customer :CustomerService ){}

  ngOnInit() : void{
    this.customer.getCustomer().subscribe((result : Customer[])=>(this.customers=result));
  }

  updateCustomerList(customers: Customer[])
  {
   this.customers=customers;
  }

  initNewCustomer()
  {
    this.customerToEdit = new Customer();
  }

  editCustomer(customer : Customer)
  {
    this.customerToEdit = customer;
  }
}
