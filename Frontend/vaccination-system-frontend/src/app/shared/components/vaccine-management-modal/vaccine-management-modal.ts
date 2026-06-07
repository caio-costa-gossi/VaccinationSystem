import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Modal } from '../modal/modal';
import { GetVaccinesItemDto } from '../../../api/vaccine/vaccine.type';

@Component({
  selector: 'app-vaccine-management-modal',
  imports: [Modal],
  templateUrl: './vaccine-management-modal.html',
  styleUrl: './vaccine-management-modal.css',
})
export class VaccineManagementModal {
  @Input({ required: true })
  vaccine!: GetVaccinesItemDto | null;

  @Output()
  closeEvent = new EventEmitter<void>();

  @Output()
  confirmVaccineDeletion = new EventEmitter<string>();

  onDeleteVaccine() {
    this.confirmVaccineDeletion.emit(this.vaccine!.id);
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }
}
