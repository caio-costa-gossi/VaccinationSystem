import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DoseManagementModal } from './dose-management-modal';

describe('DoseManagementModal', () => {
  let component: DoseManagementModal;
  let fixture: ComponentFixture<DoseManagementModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DoseManagementModal],
    }).compileComponents();

    fixture = TestBed.createComponent(DoseManagementModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
