import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Vaccines } from './vaccines';

describe('Vaccines', () => {
  let component: Vaccines;
  let fixture: ComponentFixture<Vaccines>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Vaccines],
    }).compileComponents();

    fixture = TestBed.createComponent(Vaccines);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
