import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VaccinationCard } from './vaccination-card';

describe('PersonSelector', () => {
  let component: VaccinationCard;
  let fixture: ComponentFixture<VaccinationCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VaccinationCard],
    }).compileComponents();

    fixture = TestBed.createComponent(VaccinationCard);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
