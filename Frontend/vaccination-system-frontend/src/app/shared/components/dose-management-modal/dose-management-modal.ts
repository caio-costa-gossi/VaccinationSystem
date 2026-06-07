import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Modal } from '../modal/modal';

export interface DoseManagementDto {
  vaccineName: string;
  vaccinationId: string;
  doseNumber: number;
  appliedAt: string;
}

@Component({
  selector: 'app-dose-management-modal',
  imports: [Modal],
  templateUrl: './dose-management-modal.html',
  styleUrl: './dose-management-modal.css',
})
export class DoseManagementModal {
  @Input({ required: true })
  dose!: DoseManagementDto | null;

  @Output()
  closeEvent = new EventEmitter<void>();

  @Output()
  confirmDoseDeletion = new EventEmitter<string>();

  onClose() {
    this.closeEvent.emit();
  }
  
  onDeleteDose() {
    this.confirmDoseDeletion.emit(this.dose!.vaccinationId);
    this.closeEvent.emit();
  }
}
