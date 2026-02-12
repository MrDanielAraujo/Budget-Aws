import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputDisplayFormComponent } from 'src/app/shared/form/input-display-form/input-display-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { IconesComponent } from 'src/app/shared/icones/icones.component';
import { ComboSeparador } from '../combo-separador';
import comboSeparadorValidator from './combo-separador-form-validator.json';

@Component({
  selector: 'app-combo-separador-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent, IconesComponent, InputDisplayFormComponent],
  templateUrl: './combo-separador-form.component.html',
  styleUrls: ['./combo-separador-form.component.scss']
})
export class ComboSeparadorFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<ComboSeparador>);
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "comboSeparador";
    this.crud.form.errorMessage.validatorMessageForm = comboSeparadorValidator;
    this.crud.code = this.code;
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      Nome: ['', [Validators.required]],
      Icone: ['']
    });
    this.crud.ngInitForm();
  }

  onSetIcone(icone: any) {
    //console.log(icone);
    this.crud.form.setInput("Icone", icone);
  }
}
