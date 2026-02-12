import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-input-display-form',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './input-display-form.component.html',
  styleUrls: ['./input-display-form.component.scss']
})
export class InputDisplayFormComponent {
  @Input() Label?: string = "";
  @Input() Value?: string | number;
}
