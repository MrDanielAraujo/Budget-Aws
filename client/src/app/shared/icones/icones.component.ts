import { CommonModule } from "@angular/common";
import { Component, EventEmitter, OnDestroy, Output } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { Icones } from "./icones";
import iconesData from "./icones.json";

@Component({
  selector: 'app-icones',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './icones.component.html',
  styleUrls: ['./icones.component.scss']
})
export class IconesComponent implements OnDestroy {
  
  iconsShow: boolean = false;
  filtro!: string; 
  icones: Icones = iconesData;

  @Output() eventSelect = new EventEmitter<string>(); 

  ngOnDestroy(): void {
    this.eventSelect.complete();
  }

  onIconSelect(e: Event, icone: string) {
    e.stopPropagation();
    this.eventSelect.emit(icone);
    console.log(icone);
    this.onIconsShow();
  }

  onCleanSearch() : void {
    this.filtro = '';
  }

  onGetIcons(): string[] {
    if (this.icones.solid.length === 0 || this.filtro === undefined || this.filtro.trim() === '') return this.icones.solid;
    return this.icones.solid.filter((v) => {
      return (v.toLowerCase().indexOf(this.filtro.toLowerCase()) >= 0);
    })
  }

  onIconsShow() {
    this.iconsShow = !this.iconsShow; 
  }
}