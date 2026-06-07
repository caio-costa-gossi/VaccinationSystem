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

  vaccineName = '';

  submit() {
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }
}
