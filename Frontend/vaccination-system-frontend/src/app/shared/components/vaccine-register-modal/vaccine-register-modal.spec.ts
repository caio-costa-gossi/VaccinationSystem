import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VaccineRegisterModal } from './vaccine-register-modal';

describe('VaccineRegisterModal', () => {
  let component: VaccineRegisterModal;
  let fixture: ComponentFixture<VaccineRegisterModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VaccineRegisterModal],
    }).compileComponents();

    fixture = TestBed.createComponent(VaccineRegisterModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
