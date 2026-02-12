import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModelTypeOneService } from './model-type-one.service';

@Component({
  selector: 'app-modal-type-one',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './modal-type-one.component.html',
  styleUrls: ['./modal-type-one.component.scss']
})
export class ModalTypeOneComponent {
  
  public modelTypeOneService = inject(ModelTypeOneService);
  
  filtro!:string;

}
