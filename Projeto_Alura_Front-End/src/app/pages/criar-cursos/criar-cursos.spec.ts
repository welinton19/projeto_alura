import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarCursos } from './criar-cursos';

describe('CriarCursos', () => {
  let component: CriarCursos;
  let fixture: ComponentFixture<CriarCursos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarCursos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CriarCursos);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
