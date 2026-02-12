import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class HeaderService {


  onUserInfoShow(e: Event): void {
    e.stopPropagation();
    const element = document.getElementById('userInfo');
    element?.classList.contains('user-info-show')
      ? element?.classList.remove('user-info-show')
      : element?.classList.add('user-info-show');
  }

  onUserInfoHide() {
    const element = document.getElementById('userInfo');
    element?.classList.remove('user-info-show');
  }
}