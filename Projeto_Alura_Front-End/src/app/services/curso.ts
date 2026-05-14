import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CursoService {
  
  private apiUrl = 'https://localhost:7156/api/Cursos';

  constructor(private http: HttpClient) {}

  getHeaders(){
    const token = localStorage.getItem('token');
    return new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }

  getAllCursos(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/getall`, { headers: this.getHeaders() });
}

  getByIdCurso(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`, { headers: this.getHeaders() });
  }

  createCursos(curso: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/criar`, curso, { headers: this.getHeaders() });
  }

  updateCursos(id: number, curso: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/atualizar/${id}`, curso, { headers: this.getHeaders() });
  }

  deleteCursos(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/deletar/${id}`, { headers: this.getHeaders() });
  }

}
