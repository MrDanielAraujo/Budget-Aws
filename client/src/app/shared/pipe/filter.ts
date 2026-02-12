import { Pipe, PipeTransform } from "@angular/core";
import { ComboBoxForm } from "../form/combobox-form/combobox-form";

@Pipe({
  standalone: true,
  name: 'Filter'
})
export class FilterPipe implements PipeTransform {
  transform(value: Array<ComboBoxForm> | undefined, search?: string) {
    return (value && search) ? value.filter((d) => d.Descricao.indexOf(search) > -1) : value; 
  }
}