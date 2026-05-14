import { Component, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/auth';
import { UserService } from '../../services/user';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class LoginComponent {

  Email = signal<string>('');
  Password = signal<string>('');
  error = signal<string>('');

  /**
   *
   */
  constructor(
    private userService: UserService, 
    private authService: AuthService, 
    private router: Router ) {
  }

  login(){
    this.userService.login(this.Email(), this.Password()).subscribe({
      next: (response) => {
        console.log('Resposta da API:', response);
        localStorage.setItem('token', response.token);
        
        // ✅ email vem do campo que o usuário digitou
        // ✅ role vem decodificando o token JWT
        const tokenPayload = JSON.parse(atob(response.token.split('.')[1]));
        console.log('Payload do token:', tokenPayload);
        
        const role = tokenPayload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        
        this.authService.setUsuario(this.Email(), role);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        this.error.set('Login ou senha inválidos');
      }
    });
  }

}
