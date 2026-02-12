import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {
  dataAtual: Date = new Date();
  footerTitulo: string = "";
  
  ngOnInit(): void {
    this.footerTitulo = `ICL - Todos os direitos reservados - © ${this.dataAtual.getFullYear()}`;
  }

}
