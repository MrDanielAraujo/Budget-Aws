import { CommonModule } from '@angular/common';
import { Component, inject, Input } from '@angular/core';
import { MenuPrincipal } from './menu-principal';
import menuData from "./menu-principal.json";
import { MenuPrincipalService } from './menu-principal.service';

@Component({
  selector: 'app-menu-principal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu-principal.component.html',
  styleUrls: ['./menu-principal.component.scss']
})
export class MenuPrincipalComponent {
  
  @Input() menus: MenuPrincipal[] = menuData;
  protected menuPrincipalService = inject(MenuPrincipalService);

}
