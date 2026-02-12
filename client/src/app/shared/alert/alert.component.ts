import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AlertService } from './alert.service';

@Component({
  selector: 'app-alert',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss']
})
export class AlertComponent {
  
  public alertService = inject(AlertService);

  /*
  @Output() eventCancelar = new EventEmitter();
  @Output() eventConcordar = new EventEmitter();

  onCancelar(e: Event) {
    this.eventCancelar.emit(true);
    this.alertService.clear(e);
  }

  onConcordar(e: Event) {
    this.eventConcordar.emit(false);
    this.alertService.clear(e);
  }
  */
}
