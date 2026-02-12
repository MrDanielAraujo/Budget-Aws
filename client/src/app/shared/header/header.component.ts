import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { UserInfoComponent } from 'src/app/user-info/user-info.component';
import { MenuPrincipalService } from '../menu/menu-principal/menu-principal.service';
import { UserService } from '../user/user.service';
import { HeaderService } from './header.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, UserInfoComponent],
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  protected userService = inject(UserService);
  protected headerService = inject(HeaderService);
  protected menuPrincipalService = inject(MenuPrincipalService);
  private router = inject(Router);

  //Todo colocar esse codigo na common.
  navigate(path: string | null, parameters: any[] = []): void {
    const command = parameters.length === 0 ? [path] : [path, ...parameters];
    this.router.navigate(command, { skipLocationChange: true }).then();
  }

  onStopPropagation(e: Event) {
    e.stopPropagation();
  }
}
