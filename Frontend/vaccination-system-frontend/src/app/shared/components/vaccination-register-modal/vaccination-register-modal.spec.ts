import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VaccinationRegisterModal } from './vaccination-register-modal';

describe('VaccinationRegisterModal', () => {
  let component: VaccinationRegisterModal;
  let fixture: ComponentFixture<VaccinationRegisterModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VaccinationRegisterModal],
    }).compileComponents();

    fixture = TestBed.createComponent(VaccinationRegisterModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
