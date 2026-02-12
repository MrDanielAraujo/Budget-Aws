import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { ComboboxFormComponent } from 'src/app/shared/form/combobox-form/combobox-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { CentroLucro } from '../centro-lucro';
import { CheckboxFormComponent } from './../../shared/form/checkbox-form/checkbox-form.component';
import centroLucroValidator from './centro-lucro-form-validator.json';
import { VirgulaParaPontoDirective } from 'src/app/shared/diretiva/virgula-para-ponto.directive';

@Component({
  selector: 'app-centro-lucro-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent, VirgulaParaPontoDirective],
  templateUrl: './centro-lucro-form.component.html',
  styleUrls: ['./centro-lucro-form.component.scss']
})
export class CentroLucroFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<CentroLucro>);
  protected data?:CentroLucro;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroLucro";
    this.crud.form.errorMessage.validatorMessageForm = centroLucroValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as CentroLucro );
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      IdCentroClasse: [''],
      IdCentroEmpresa: [''],
      IdCentroFilial: [''],
      IdCentroDiretoria: [''],
      IdCentroCategoria: [''],
      Codigo: ['', [Validators.required]],
      Nome: ['', [Validators.required]],
      Imposto: [''],
      Pdd: [''],
      Bloqueado: [''],
      // PreenchedorEmail: ['']
    });
    this.crud.ngInitForm();
  }
}
