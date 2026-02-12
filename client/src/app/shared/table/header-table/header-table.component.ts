import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-header-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header-table.component.html',
  styleUrls: ['./header-table.component.scss']
})
export class HeaderTableComponent {
  @Input() title: string = "";
  @Input() icone: string = "";
}
