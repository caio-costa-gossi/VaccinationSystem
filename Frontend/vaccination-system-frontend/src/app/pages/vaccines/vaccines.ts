import { Component } from '@angular/core';
import { GetVaccinesItemDto } from '../../api/vaccine/vaccine.type';
import { VaccineRegisterModal } from '../../shared/components/vaccine-register-modal/vaccine-register-modal';

@Component({
  selector: 'app-vaccines',
  imports: [VaccineRegisterModal],
  templateUrl: './vaccines.html',
  styleUrl: './vaccines.css',
})
export class Vaccines {
  vaccines: GetVaccinesItemDto[];
  showVaccineModal: boolean = false;

  constructor() {
    this.vaccines = [
      {
        id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
        name: 'Vacina 1'
      },
      {
        id: 'e8b79d52-cd76-49ef-a710-a6d6b4e8dfcf',
        name: 'Vacina 2'
      }
    ];
  }

  onVaccineClick(vaccineId: string) {
    console.log(`Manage vaccine with ID ${vaccineId}`);
  }

  onRegisterVaccine() {
    console.log('Register vaccine');
    this.showVaccineModal = true;
  }
}
