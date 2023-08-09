import { Component } from '@angular/core';
import { Album } from './models/music-shop';
import { MusicShopService } from './services/music-shop.service';
import { Router } from '@angular/router';
import { UserAutho } from './models/admin';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MusicShop.UI';
  
  constructor(private route:Router){}

   gotoalbum(){
       this.route.navigate(["/album"]);
   }

   gotocustomer(){
    this.route.navigate(["/customer"]);
  }

  gotorecord(){
    this.route.navigate(["/record"]);
  }

  gotologin()
  {
    this.route.navigate(["/login"]);
  }

}
