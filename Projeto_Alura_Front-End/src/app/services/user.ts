import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  
  private apiUrl = 'https://localhost:7156/api/User';

  constructor(private http: HttpClient) {}

  private getHeaders(){
    const token = localStorage.getItem('token');
    return new HttpHeaders({'Authorization': `Bearer ${token}`});
  }

  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { email, password });
  }

  register(email: string, password: string, role: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, { email, password, role });
  }

  updateUser(id: number, email: string, password: string, role: string): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/atualizar/${id}`, { email, password, role }, { headers: this.getHeaders() });
  }

  getUserById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/deletar/${id}`, { headers: this.getHeaders() });
  }

  logout(): Observable<any> {
    
    return this.http.post<any>(`${this.apiUrl}/logout`,  {headers : this.getHeaders()});
  }
}
