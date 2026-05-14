import { Component, OnInit, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class HeaderComponent implements OnInit {

  email = signal('');
  role = signal('');

  dropdownOpen = signal(false);

  /**
   *
   */
  constructor(
    private authService: AuthService, 
    private router: Router) {
    
    
  }

  ngOnInit() {
    this.email.set(this.authService.getEmailUsuario() ?? '');
    this.role.set(this.authService.getRoleUsuario() ?? '');
  }


  toggleDropdown() {
    this.dropdownOpen.set(!this.dropdownOpen());
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
