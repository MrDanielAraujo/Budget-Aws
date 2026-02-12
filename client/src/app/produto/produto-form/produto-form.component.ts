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
import { Produto } from '../produto';
import produtoValidator from './produto-form-validator.json';

@Component({
  selector: 'app-produto-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.scss']
})
export class ProdutoFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<Produto>);
  protected data?:Produto;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "produto";
    this.crud.form.errorMessage.validatorMessageForm = produtoValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as Produto );
    this.crud.form.formGroup = this.fb.group({
      Id:[null],
      Codigo:[null, [Validators.required]],
      Nome:[null, [Validators.required]],
      IdCentroFilial:[null, [Validators.required]],
      IdMercado:[null, [Validators.required]],
      Linha:[null],
      Custo:[null],
    });
    this.crud.ngInitForm();
  }
}
