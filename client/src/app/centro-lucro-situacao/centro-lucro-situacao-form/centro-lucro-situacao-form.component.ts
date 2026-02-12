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
import { InputDisplayFormComponent } from 'src/app/shared/form/input-display-form/input-display-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { CentroLucroSituacao } from '../centro-lucro-situacao';
import centroLucroSituacaoValidator from './centro-lucro-situacao-form-validator.json';

@Component({
  selector: 'app-centro-lucro-situacao-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent, InputDisplayFormComponent],
  templateUrl: './centro-lucro-situacao-form.component.html',
  styleUrls: ['./centro-lucro-situacao-form.component.scss']
})
export class CentroLucroSituacaoFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<CentroLucroSituacao>);
  protected data?:CentroLucroSituacao;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroLucroSituacao";
    this.crud.form.errorMessage.validatorMessageForm = centroLucroSituacaoValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as CentroLucroSituacao );
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      IdExercicio: ['', [Validators.required]],
      IdCentroLucro: ['', [Validators.required]],
      IdCentroStatus: ['', [Validators.required]],
      IdCentroLucroUsuario: [''],
    });
    this.crud.ngInitForm();
  }
}
