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
import { CentroCustoUsuario } from '../centro-custo-usuario';
import centroCustoUsuarioValidator from './centro-custo-usuario-form-validator.json';

@Component({
  selector: 'app-centro-custo-usuario-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './centro-custo-usuario-form.component.html',
  styleUrls: ['./centro-custo-usuario-form.component.scss']
})
export class CentroCustoUsuarioFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<CentroCustoUsuario>);
  protected data?:CentroCustoUsuario;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroCustoUsuario";
    this.crud.form.errorMessage.validatorMessageForm = centroCustoUsuarioValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as CentroCustoUsuario );
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      IdCentroCusto: ['', [Validators.required]],
      Email: ['', [Validators.required]],
      Nivel: ['', [Validators.required]]
    });
    this.crud.ngInitForm();
  }
}
