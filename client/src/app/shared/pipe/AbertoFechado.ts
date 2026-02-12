import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  standalone: true,
  name: 'AbertoFechado'
})
export class AbertoFechadoPipe implements PipeTransform {
  transform(value: boolean, ...args: any[]): any {
      return (value == true) ? 'Aberto' : 'Fechado';
  }
}