import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Modal } from '../modal/modal';

@Component({
  selector: 'app-vaccination-register-modal',
  imports: [FormsModule, Modal],
  templateUrl: './vaccination-register-modal.html',
  styleUrl: './vaccination-register-modal.css',
})
export class VaccinationRegisterModal {
  @Output() closeEvent = new EventEmitter<void>();

  vaccines = [
    { id: '1', name: 'Vacina A' },
    { id: '2', name: 'Vacina B' }
  ];

  selectedVaccineId = '';
  doseNumber = 1;
  applicationDate = '';

  submit() {
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }
}
