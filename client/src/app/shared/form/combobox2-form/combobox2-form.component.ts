import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from '../../pipe/filter';
import { ComboBoxForm } from '../combobox-form/combobox-form';

@Component({
  selector: 'app-combobox2-form',
  standalone: true,
  imports: [CommonModule, FilterPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './combobox2-form.component.html',
  styleUrls: ['./combobox2-form.component.scss']
})
export class Combobox2FormComponent {

  @Input() input: string = "";
  @Input() label?: string = "";
  @Input() class?: string = "";
  @Input() submit: boolean = false;
  @Input() control: FormControl = new FormControl();
  @Input() options?: ComboBoxForm[];
  @Input() classInput?: string = "";
  @Input() url?: string = "";
  
  protected showSelectOptions: boolean = false;
  @Input() descricao?: string = "";
  public searchValue?: string;

  public close() {
    this.showSelectOptions = false;
  }

  public selectItem(item:ComboBoxForm = new ComboBoxForm()) {
    this.control.setValue(item?.Id);
    this.descricao = item?.Descricao;
    this.close();
  }

  public getValueServer():void {

    if(this.options != null && this.options.length >= 1)
    {
      this.showSelectOptions = true;
      return;
    } 

  }

  onInputInvalid(): boolean {
    return this.control.touched;
  }

}
