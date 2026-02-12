import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-header-form',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header-form.component.html',
  styleUrls: ['./header-form.component.scss']
})
export class HeaderFormComponent {
  @Input() title: string = "";
  @Input() icone: string = "";
  @Input() btnCreateShow: boolean = true;
  
}
