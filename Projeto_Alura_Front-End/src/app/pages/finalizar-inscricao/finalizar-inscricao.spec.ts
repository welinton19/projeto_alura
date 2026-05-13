import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinalizarInscricao } from './finalizar-inscricao';

describe('FinalizarInscricao', () => {
  let component: FinalizarInscricao;
  let fixture: ComponentFixture<FinalizarInscricao>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FinalizarInscricao]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FinalizarInscricao);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
