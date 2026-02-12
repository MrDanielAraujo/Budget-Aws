import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { Exercicio } from '../exercicio';
import exercicioValidator from "./exercicio-form-validator.json";

@Component({
  selector: 'app-exercicio-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './exercicio-form.component.html',
  styleUrls: ['./exercicio-form.component.scss']
})
export class ExercicioFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<Exercicio>);
  
  @Input() code!: string;

  /**
   * * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "exercicio";
    this.crud.form.errorMessage.validatorMessageForm = exercicioValidator;
    this.crud.code = this.code;
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      Ano: ['', [Validators.required]],
      Aberto: ['']
    },);    
    this.crud.ngInitForm();
  }
}
