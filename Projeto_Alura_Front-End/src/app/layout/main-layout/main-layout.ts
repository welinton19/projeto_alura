import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header";
import { FooterComponent } from "../footer/footer";



@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [HeaderComponent, FooterComponent],
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.css',
})
export class MainLayoutComponent {

}
