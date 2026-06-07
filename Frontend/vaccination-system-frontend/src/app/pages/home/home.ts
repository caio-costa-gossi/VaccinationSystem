import { Component } from '@angular/core';
import { VaccinationCard } from './vaccination-card/vaccination-card';
import { GetPersonsItemDto } from '../../api/person/person.type';
import { PersonModal } from '../../shared/components/person-modal/person-modal';

@Component({
  selector: 'app-home',
  imports: [VaccinationCard, PersonModal],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  people: GetPersonsItemDto[] = [
    {name: 'João', id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f'},
    {name: 'Bruno', id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f'},
    {name: 'Carlos', id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f'},
    {name: 'Daniela', id: '42cb0f45-7461-4316-8b9e-6465fec2dd4f'}
  ];

  selectedPersonId: string | null = null;

  showRegisterPersonModal: boolean = false;

  onSelect(event: EventTarget | null) {
    let htmlEvent = event as HTMLSelectElement;
    
    if (!htmlEvent)
      return;
    
    this.selectedPersonId = htmlEvent.value;
  }

  onRegisterPerson() {
    this.showRegisterPersonModal = true;
  }

  onPersonDeleted() {
    this.selectedPersonId = null;
  }
}
