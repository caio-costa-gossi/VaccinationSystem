import { Component, EventEmitter, Output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Modal } from '../modal/modal';

@Component({
  selector: 'app-person-modal',
  imports: [FormsModule, Modal],
  templateUrl: './person-modal.html',
  styleUrl: './person-modal.css',
})
export class PersonModal {
  @Output() closeEvent = new EventEmitter<void>();
  @Output() confirmRegisterEvent = new EventEmitter<string>();

  name = '';

  submit() {
    this.confirmRegisterEvent.emit(this.name);
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }

  allFieldsValid(): boolean {
    return !!this.name && this.name.trim() !== '';
  }
}
