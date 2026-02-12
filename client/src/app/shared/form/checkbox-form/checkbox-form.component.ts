import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-checkbox-form',
  standalone: true,
  imports: [CommonModule , FormsModule, ReactiveFormsModule],
  templateUrl: './checkbox-form.component.html',
  styleUrls: ['./checkbox-form.component.scss']
})
export class CheckboxFormComponent {
  @Input() input?: string = "";
  @Input() label?: string = "";
  @Input() control: FormControl = new FormControl();
  @Input() class?: string = "";
  @Input() classInput?: string = "";
}
