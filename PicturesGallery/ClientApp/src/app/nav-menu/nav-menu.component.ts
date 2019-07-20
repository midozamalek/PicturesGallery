import { Component } from '@angular/core';
import { AuthenticationService } from '../authentication-service';
import { debounce } from 'rxjs/operators';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  IsAuthenticated = false;
  private _authenticationService: AuthenticationService;

  constructor(private authenticationService: AuthenticationService) {
    debugger;
    this.IsAuthenticated = authenticationService.IsAuthinticated();
    this._authenticationService = authenticationService;
  }
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  Logout() {
    debugger;
    this.authenticationService.logout();
    window.location.reload();
  }
}
