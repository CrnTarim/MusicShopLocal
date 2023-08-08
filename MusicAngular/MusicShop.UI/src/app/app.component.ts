import { Component } from '@angular/core';
import { Album } from './models/music-shop';
import { MusicShopService } from './services/music-shop.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MusicShop.UI';
  
}
