import { Component, OnInit, signal } from '@angular/core';
import { GetVaccinesItemDto } from '../../api/vaccine/vaccine.type';
import { VaccineRegisterModal } from '../../shared/components/vaccine-register-modal/vaccine-register-modal';
import { VaccineService } from '../../api/vaccine/vaccine.service';
import { Spinner } from '../../shared/components/spinner/spinner';
import { VaccineManagementModal } from '../../shared/components/vaccine-management-modal/vaccine-management-modal';

@Component({
  selector: 'app-vaccines',
  imports: [VaccineRegisterModal, VaccineManagementModal, Spinner],
  templateUrl: './vaccines.html',
  styleUrl: './vaccines.css',
})
export class Vaccines implements OnInit {
  vaccines: GetVaccinesItemDto[] = [];
  selectedVaccine: GetVaccinesItemDto | null = null;
  
  showVaccineRegisterModal: boolean = false;
  showVaccineManagementModal: boolean = false;

  isLoading = signal(false);

  constructor(private vaccineService: VaccineService) {}

  ngOnInit(): void {
    this.loadVaccines();
  }

  loadVaccines() {
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

  onVaccineClick(vaccine: GetVaccinesItemDto) {
    this.showVaccineManagementModal = true;
    this.selectedVaccine = vaccine;
  }

  onConfirmDeleteVaccine(vaccineId: string) {

  }

  onRegisterVaccine() {
    this.showVaccineRegisterModal = true;
  }

  onConfirmRegisterVaccine(vaccineName: string) {
    this.vaccineService.create(vaccineName).subscribe({
      next: (data) => {
        this.loadVaccines();
      },
      error: (err) => {
        console.error('Post failed', err);
        this.isLoading.set(false);
      }
    });
  }
}
