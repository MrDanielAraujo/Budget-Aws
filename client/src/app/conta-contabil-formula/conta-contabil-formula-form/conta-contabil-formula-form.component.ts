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
import { ContaContabilFormula } from '../conta-contabil-formula';
import contaContabilFormulaValidator from './conta-contabil-formula-form-validator.json';

@Component({
  selector: 'app-conta-contabil-formula-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './conta-contabil-formula-form.component.html',
  styleUrls: ['./conta-contabil-formula-form.component.scss']
})
export class ContaContabilFormulaFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<ContaContabilFormula>);
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "contaContabilFormula";
    this.crud.form.errorMessage.validatorMessageForm = contaContabilFormulaValidator;
    this.crud.code = this.code;
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      Formula: ['', [Validators.required]],
      Descricao: ['', [Validators.required]],
    });
    this.crud.ngInitForm();
  }
}
