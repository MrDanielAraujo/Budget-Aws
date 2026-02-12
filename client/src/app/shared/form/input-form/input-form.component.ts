import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-input-form',
  standalone: true,
  host: {'[class.input-danger]':'error',},
  imports: [CommonModule, FormsModule, ReactiveFormsModule, NgxMaskDirective, NgxMaskPipe],
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.scss'],
  providers: [provideNgxMask()]
})
export class InputFormComponent {
  @Input() input?: string = "";
  @Input() label?: string = "";
  @Input() type?: 'text' | 'password' | 'email' | 'number' | 'hidden' | 'tel';
  @Input() control: FormControl = new FormControl();
  @Input() mask?: string = "";
  @Input() error: boolean = false;
  @Input() dropSpecialCharacters: boolean = false;
  @Input() decimalMarker: any = "";
  @Input() thousandSeparator: any = "";

  onInputInvalid(): boolean {
    return this.control.touched;
  }
}