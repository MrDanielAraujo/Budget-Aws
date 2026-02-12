import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { ComboboxFormComponent } from 'src/app/shared/form/combobox-form/combobox-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { ContaContabil } from '../conta-contabil';
import contaContabilValidator from './conta-contabil-form-validator.json';

@Component({
  selector: 'app-conta-contabil-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, ComboboxFormComponent ,CheckboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './conta-contabil-form.component.html',
  styleUrls: ['./conta-contabil-form.component.scss']
})
export class ContaContabilFormComponent  implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<ContaContabil>);
  protected data?:ContaContabil;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "contaContabil";
    this.crud.form.errorMessage.validatorMessageForm = contaContabilValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as ContaContabil );
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      IdContaContabilFormula: [''],
      IdContaContabilClassificacao: [''],
      Nome: ['', [Validators.required]],
      Codigo: ['', [Validators.required]],
      Digito: ['', [Validators.required]],
      Limite: ['', [Validators.required]],
      Visualizar: [''],
      Help: ['', [Validators.required]],
      NaoAceitaCalculo: [''],
      ExigeJustificativa: ['']
    });
    this.crud.ngInitForm();
  }

}
