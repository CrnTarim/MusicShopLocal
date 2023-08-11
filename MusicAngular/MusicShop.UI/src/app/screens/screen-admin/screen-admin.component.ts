import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserAutho } from 'src/app/models/admin';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-screen-admin',
  templateUrl: './screen-admin.component.html',
  styleUrls: ['./screen-admin.component.css']
})
export class ScreenAdminComponent {

  title = 'MusicShop.UI';
  admin= new UserAutho();

  nameExceedsLimit = false;
  passwordExceedsLimit = false;
  
  constructor(private adminService : AdminService, private router:Router ){}
   
  register(admin : UserAutho)
   {
      this.adminService.register(admin).subscribe();
   }

   login(admin : UserAutho)
   {
      this.adminService.login(admin).subscribe((token: string)=>{localStorage.setItem('authToken', token)});
   }
   
   
   checkCharacterLimit(value: string, limit: number, field: string): void {
    if (value.length > limit) {
        if (field === 'name') {
            this.nameExceedsLimit = true;
        } else if (field === 'password') {
            this.passwordExceedsLimit = true;
        }
    } else {
        if (field === 'name') {
            this.nameExceedsLimit = false;
        } else if (field === 'password') {
            this.passwordExceedsLimit = false;
        }
    }
}

}
