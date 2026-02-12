import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FooterFormBtn } from './footer-form-btn';

@Component({
  selector: 'app-footer-form',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer-form.component.html',
  styleUrls: ['./footer-form.component.scss']
})
export class FooterFormComponent {

  @Input() showFooterBtn!: FooterFormBtn;

  @Output() eventVoltar = new EventEmitter();
  @Output() eventCancelar = new EventEmitter();
  @Output() eventEditar = new EventEmitter();
  @Output() eventDeletar = new EventEmitter();

  onVoltar(): void {
    this.eventVoltar.emit();
  }

  onCancelar(): void {
    this.eventCancelar.emit();
  }

  onEditar(): void {
    this.eventEditar.emit();
  }

  onDeletar(): void {
    this.eventDeletar.emit();
  }
}
