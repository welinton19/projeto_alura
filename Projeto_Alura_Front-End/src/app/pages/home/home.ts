import { Component, OnInit, signal } from '@angular/core';
import { MainLayoutComponent } from '../../layout/main-layout/main-layout';
import { CursoService } from '../../services/curso';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MainLayoutComponent],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class HomeComponent implements OnInit {

  cursos = signal<any[]>([]);
 cursosPaginados = signal<any[]>([]);
 paginaAtual = signal(1);
 itensPorPagina = 6;

  /**
   *
   */
  constructor(
    private cursoService: CursoService, 
    public authService: AuthService) {
    
    
  }

ngOnInit() {
    this.cursoService.getAllCursos().subscribe({
      next: (response) => {
        console.log('Primeiro curso:', response[0]); 
        this.cursos.set(response);
        this.atualizarPagina();
      },
      error: (err) => {
        console.log('Erro ao buscar cursos:', err);
      }
    });
}
atualizarPagina() {
    const inicio = (this.paginaAtual() - 1) * this.itensPorPagina;
    const fim = inicio + this.itensPorPagina;
    this.cursosPaginados.set(this.cursos().slice(inicio, fim));
}

proximaPagina() {
    if (this.paginaAtual() * this.itensPorPagina < this.cursos().length) {
        this.paginaAtual.update(p => p + 1);
        this.atualizarPagina();
    }
}

paginaAnterior() {
    if (this.paginaAtual() > 1) {
        this.paginaAtual.update(p => p - 1);
        this.atualizarPagina();
    }
}

totalPaginas() {
    return Math.ceil(this.cursos().length / this.itensPorPagina);
}
  

}
