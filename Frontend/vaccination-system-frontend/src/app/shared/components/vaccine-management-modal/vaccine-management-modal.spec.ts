import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VaccineManagementModal } from './vaccine-management-modal';

describe('VaccineManagementModal', () => {
  let component: VaccineManagementModal;
  let fixture: ComponentFixture<VaccineManagementModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VaccineManagementModal],
    }).compileComponents();

    fixture = TestBed.createComponent(VaccineManagementModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
