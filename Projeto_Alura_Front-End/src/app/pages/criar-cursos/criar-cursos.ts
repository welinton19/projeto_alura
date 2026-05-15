import { Component } from '@angular/core';
import { HeaderComponent } from "../../layout/header/header";
import { FooterComponent } from "../../layout/footer/footer";

@Component({
  selector: 'app-criar-cursos',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './criar-cursos.html',
  styleUrl: './criar-cursos.css',
})
export class CriarCursosComponent {

}
