import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ComboBoxForm } from './combobox-form';

@Component({
  selector: 'app-combobox-form',
  standalone: true,
  host: {'[class.input-danger]':'error',},
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './combobox-form.component.html',
  styleUrls: ['./combobox-form.component.scss']
})
export class ComboboxFormComponent {

  @Input() input: string = "";
  @Input() label?: string = "";
  @Input() class?: string = "";
  @Input() control: FormControl = new FormControl();
  @Input() options?: ComboBoxForm[];
  @Input() classInput?: string = "";
  @Input() error: boolean = false;
  
}
