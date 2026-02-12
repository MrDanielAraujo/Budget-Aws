import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  standalone: true,
  name: 'CleanValue'
})
export class CleanValuePipe implements PipeTransform {
  transform(value: string): null {
    return null;
  }
}