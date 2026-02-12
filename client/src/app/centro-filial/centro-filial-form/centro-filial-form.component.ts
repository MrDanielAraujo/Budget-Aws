import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { ComboboxFormComponent } from 'src/app/shared/form/combobox-form/combobox-form.component';
import { Combobox2FormComponent } from 'src/app/shared/form/combobox2-form/combobox2-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { CentroFilial } from '../centro-filial';
import centroFilialValidator from './centro-filial-form-validator.json';

@Component({
  selector: 'app-centro-filial-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent, Combobox2FormComponent, ComboboxFormComponent],
  templateUrl: './centro-filial-form.component.html',
  styleUrls: ['./centro-filial-form.component.scss']
})
export class CentroFilialFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<CentroFilial>);
  protected data?:CentroFilial;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroFilial";
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as CentroFilial );
    this.crud.form.errorMessage.validatorMessageForm = centroFilialValidator;
    this.crud.code = this.code;
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      Codigo: ['', [Validators.required, Validators.maxLength(6)]],
      Nome: ['', [Validators.required]],
      IdEmpresa: ['', [Validators.required]]
    });
    this.crud.ngInitForm();
  }
}
