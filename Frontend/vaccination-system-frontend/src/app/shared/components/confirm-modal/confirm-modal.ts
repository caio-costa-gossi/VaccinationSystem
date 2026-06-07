import { Component, EventEmitter, Output } from '@angular/core';
import { Modal } from '../modal/modal';

@Component({
  selector: 'app-confirm-modal',
  imports: [Modal],
  templateUrl: './confirm-modal.html',
  styleUrl: './confirm-modal.css',
})
export class ConfirmModal {
  @Output() confirm = new EventEmitter<boolean>();
  @Output() closeEvent = new EventEmitter<void>();

  yes() {
    this.confirm.emit(true);
  }

  no() {
    this.confirm.emit(false);
  }

  onClose() {
    this.closeEvent.emit();
  }
}
