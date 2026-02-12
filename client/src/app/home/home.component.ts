import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Command } from '../shared/global/command';
import { MsalToken } from '../shared/msal/msal-token.service';
import { UserService } from '../shared/user/user.service';
import { CentroCustoComponent } from './centro-custo/centro-custo.component';
import { CentroLucroComponent } from './centro-lucro/centro-lucro.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterOutlet, CentroCustoComponent, CentroLucroComponent],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  private msalToken = inject(MsalToken);
  protected userService = inject(UserService);
  protected command = inject(Command);
  private element!: Element | null;
  
  ngOnInit(): void {
    this.element = null;
  }

  onNavigate(path: string): void {
    this.command.navigate(path);
    if(this.element != null) this.element.scrollTop = 0;
  }

  onScroll(event: any): void {
    this.element = event.target;
  }

  
}
