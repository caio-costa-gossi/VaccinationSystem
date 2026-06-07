import { Component, OnInit, signal } from '@angular/core';
import { GetVaccinesItemDto } from '../../api/vaccine/vaccine.type';
import { VaccineRegisterModal } from '../../shared/components/vaccine-register-modal/vaccine-register-modal';
import { VaccineService } from '../../api/vaccine/vaccine.service';
import { Spinner } from '../../shared/components/spinner/spinner';

@Component({
  selector: 'app-vaccines',
  imports: [VaccineRegisterModal, Spinner],
  templateUrl: './vaccines.html',
  styleUrl: './vaccines.css',
})
export class Vaccines implements OnInit {
  vaccines: GetVaccinesItemDto[] = [];
  showVaccineModal: boolean = false;

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
        console.log(this.vaccines);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Fetch failed', err);
        this.isLoading.set(false);
      }
    });
  }

  onVaccineClick(vaccineId: string) {
    console.log(`Manage vaccine with ID ${vaccineId}`);
  }

  onRegisterVaccine() {
    console.log('Register vaccine');
    this.showVaccineModal = true;
  }
}
