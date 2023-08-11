import { Component } from '@angular/core';
import { Customer } from 'src/app/models/customer-shop';
import { CustomerService } from 'src/app/services/customer-service.service';
import * as signalR from '@microsoft/signalr';

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

    // const connection = new signalR.HubConnectionBuilder()
    // .withUrl('https://localhost:7142/notify')
    // .configureLogging(signalR.LogLevel.Information)
    // .build();

    // connection.start()
    // .then(function () {
    //     console.log('SignalR Customer Connected!');
    // })
    // .catch(function (err) {
    //     return console.error(err.toString());
    // });

    // connection.on("BroadcastMessage", () => {  
    //   this.customer.getCustomer().subscribe((result : Customer[])=>(this.customers=result));

    // });  
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
