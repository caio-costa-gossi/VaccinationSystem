import { Component, Input } from '@angular/core';
import { GetPersonDto } from '../../../api/person/person.type';
import { GetVaccinationDto } from '../../../api/vaccination/vaccination.type';

type Vaccination = {
  vaccineId: string;
  vaccineName: string;
  appliedDoses: {
    vaccinationId: string;
    doseNumber: number;
    appliedAt: string;
  }[];
};

@Component({
  selector: 'app-vaccination-card',
  imports: [],
  templateUrl: './vaccination-card.html',
  styleUrl: './vaccination-card.css',
})
export class VaccinationCard {
  @Input() personId!: string;

  person: GetPersonDto;
  vaccinations: Vaccination[] = [];

  constructor() {
    this.person = {
      id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
      name: 'João',
      vaccinations: [
        {
          id: '67e9c81d-348f-4607-82cb-e5e0d2f1d7c5',
          vaccine: {
              vaccineId: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
              vaccineName: 'Vacina 1'
          },
          doseNumber: 1,
          appliedAt: '2026-01-01'
        },
        {
          id: '8981009e-ce0e-48c8-9609-f4c101b53c3f',
          vaccine: {
              vaccineId: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
              vaccineName: 'Vacina 1'
          },
          doseNumber: 2,
          appliedAt: '2026-01-02'
        },
        {
          id: '4baefb05-76d5-441a-831c-7a9177d820bf',
          vaccine: {
              vaccineId: 'e8b79d52-cd76-49ef-a710-a6d6b4e8dfcf',
              vaccineName: 'Vacina 2'
          },
          doseNumber: 1,
          appliedAt: '2026-01-03'
        }
      ]
    };
    
    this.vaccinations = this.mapVaccinations(this.person.vaccinations);
  }

  onDeletePerson() {
    console.log('Person deleted!');
    console.log(this.vaccinations);
  }

  onRegisterVaccination() {
    console.log('Vaccination registered!');
  }

  onDoseClick(vaccinationId: string) {
    console.log(`Manage dose with ID: ${vaccinationId}`);
  }

  mapVaccinations(data: GetVaccinationDto[]): Vaccination[] {
    const map = new Map<string, Vaccination>();

    for (const item of data) {
      const vaccineId = item.vaccine.vaccineId;

      if (!map.has(vaccineId)) {
        map.set(vaccineId, {
          vaccineId,
          vaccineName: item.vaccine.vaccineName,
          appliedDoses: []
        });
      }

      map.get(vaccineId)!.appliedDoses.push({
        vaccinationId: item.id,
        doseNumber: item.doseNumber,
        appliedAt: item.appliedAt
      });
    }

    return Array.from(map.values());
  }
}
