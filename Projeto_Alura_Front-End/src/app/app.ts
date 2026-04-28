import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: true,
  styleUrl: './app.css',
  imports: [RouterOutlet]
})
export class App {
  protected readonly title = signal('Projeto_Alura_Front-End');
}
