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
import { FuncionarioCargo } from '../funcionario-cargo';
import funcionarioCargoValidator from './funcionario-cargo-form-validator.json';

@Component({
  selector: 'app-funcionario-cargo-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './funcionario-cargo-form.component.html',
  styleUrls: ['./funcionario-cargo-form.component.scss']
})
export class FuncionarioCargoFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<FuncionarioCargo>);
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "funcionarioCargo";
    this.crud.form.errorMessage.validatorMessageForm = funcionarioCargoValidator;
    this.crud.code = this.code;
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      Nome: ['', [Validators.required]],
    });
    this.crud.ngInitForm();
  }
}
