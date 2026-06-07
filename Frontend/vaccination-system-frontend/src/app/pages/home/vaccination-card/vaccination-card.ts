import { Component, Input } from '@angular/core';
import { GetPersonDto } from '../../../api/person/person.type';

@Component({
  selector: 'app-vaccination-card',
  imports: [],
  templateUrl: './vaccination-card.html',
  styleUrl: './vaccination-card.css',
})
export class VaccinationCard {
  @Input() personId!: string;

  person: GetPersonDto;

  constructor() {
    this.person = {
      id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
      name: 'João',
      vaccines: [
        {
          id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
          vaccine: {
              vaccineId: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
              vaccineName: 'Vacina 1'
          },
          doseNumber: 1,
          appliedAt: '2026-01-01'
        },
        {
          id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
          vaccine: {
              vaccineId: '42cb0f45-7461-4316-8b9e-6465fec2dd4f',
              vaccineName: 'Vacina 2'
          },
          doseNumber: 1,
          appliedAt: '2026-01-01'
        }
      ]
    };
  }

  onDeletePerson() {
    console.log('Person deleted!');
  }

  onRegisterVaccination() {
    console.log('Vaccination registered!');
  }
}
