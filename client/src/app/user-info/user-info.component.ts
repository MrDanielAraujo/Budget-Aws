import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { UserService } from './../shared/user/user.service';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
    protected userService = inject(UserService);
    private nameFirstLetter = this.userService.currentUser()?.givenName.charAt(0).toUpperCase();
    private surNameFirstLetter = this.userService.currentUser()?.surname.charAt(0).toUpperCase();
    protected currentUserLetters = `${this.nameFirstLetter}${this.surNameFirstLetter}`;
    private authService = inject(MsalService);
    
    onSignOut() {
      this.authService.logoutRedirect();
      //{ postLogoutRedirectUri: 'http://localhost:4200/logged',}
    }
    
}
