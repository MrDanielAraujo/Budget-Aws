import { Directive, HostListener, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

@Directive({
  selector: '[virgulaParaPonto]',
  standalone: true,
})
export class VirgulaParaPontoDirective {
  @Input() control!: FormControl;

  @HostListener('input', ['$event']) onInputChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    const newValue = input.value.replace(',', '.');

    input.value = newValue;

    this.control.setValue(newValue);
  }
}
