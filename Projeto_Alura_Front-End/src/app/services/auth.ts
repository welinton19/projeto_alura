import { Injectable, signal } from '@angular/core';
import { Roles } from '../models/roles';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  
  private emailUsuario = signal<string>('');
  private roleUsuario = signal<string>('');

  setUsuario(email: string,  role: string) {
    this.emailUsuario.set(email);
    this.roleUsuario.set(role); 
    localStorage.setItem('emailUsuario', email);
    localStorage.setItem('roleUsuario', role);
  }

  getEmailUsuario() {
    return this.emailUsuario() || localStorage.getItem('emailUsuario');
  }

  getRoleUsuario() {
    return this.roleUsuario() || localStorage.getItem('roleUsuario');
    
  }

  isAdmin() {
    return this.getRoleUsuario() === Roles.Admin;
  }

  isInstructor() {
    return this.getRoleUsuario() === Roles.Instructor;
  }

  isStudent() {
    return this.getRoleUsuario() === Roles.Student;
  }

  logout() {
    this.emailUsuario.set('');
    this.roleUsuario.set('');
    localStorage.removeItem('emailUsuario');
    localStorage.removeItem('roleUsuario');
    localStorage.removeItem('token');
  }
  isLoggedIn() {
    return !!localStorage.getItem('token');
  }
}
