import { Component, EventEmitter, Output } from '@angular/core';
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

  name = '';

  submit() {
    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }
}
