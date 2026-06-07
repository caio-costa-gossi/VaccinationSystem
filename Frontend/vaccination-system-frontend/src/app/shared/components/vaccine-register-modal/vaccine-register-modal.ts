import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Modal } from '../modal/modal';

@Component({
  selector: 'app-vaccine-register-modal',
  imports: [FormsModule, Modal],
  templateUrl: './vaccine-register-modal.html',
  styleUrl: './vaccine-register-modal.css',
})
export class VaccineRegisterModal {
  @Output() closeEvent = new EventEmitter<void>();

  @Output() confirmRegisterEvent = new EventEmitter<string>();

  vaccineName = '';

  submit() {
    this.confirmRegisterEvent.emit(this.vaccineName);
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }

  allFieldsValid(): boolean {
    return !!this.vaccineName && this.vaccineName.trim() !== '';
  }
}
