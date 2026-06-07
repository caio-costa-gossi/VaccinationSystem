import { Component, EventEmitter, OnInit, Output, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Modal } from '../modal/modal';
import { VaccineService } from '../../../api/vaccine/vaccine.service';
import { GetVaccinesItemDto } from '../../../api/vaccine/vaccine.type';
import { Spinner } from '../spinner/spinner';

export interface NewVaccination {
  vaccineId: string;
  doseNumber: number;
  applicationDate: string;
}

@Component({
  selector: 'app-vaccination-register-modal',
  imports: [FormsModule, Modal, Spinner],
  templateUrl: './vaccination-register-modal.html',
  styleUrl: './vaccination-register-modal.css',
})
export class VaccinationRegisterModal implements OnInit {
  @Output() closeEvent = new EventEmitter<void>();
  @Output() confirmRegisterEvent = new EventEmitter<NewVaccination>();

  vaccines: GetVaccinesItemDto[] = [];

  selectedVaccineId = '';
  doseNumber = 1;
  applicationDate = '';

  isLoading = signal(false);

  constructor(private vaccineService: VaccineService) {}

  ngOnInit(): void {
    this.loadVaccineList();
  }

  loadVaccineList() {
    this.isLoading.set(true);
    
    this.vaccineService.getAll().subscribe({
      next: (data) => {
        this.vaccines = data;
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Fetch failed', err);
        this.isLoading.set(false);
      }
    });
  }

  submit() {
    this.confirmRegisterEvent.emit({
      vaccineId: this.selectedVaccineId,
      doseNumber: this.doseNumber,
      applicationDate: this.applicationDate
    });

    this.closeEvent.emit();
  }

  onClose() {
    this.closeEvent.emit();
  }
}
