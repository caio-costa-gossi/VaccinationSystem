import { Component, OnInit, signal } from '@angular/core';
import { VaccinationCard } from './vaccination-card/vaccination-card';
import { GetPersonsItemDto } from '../../api/person/person.type';
import { PersonModal } from '../../shared/components/person-modal/person-modal';
import { PersonService } from '../../api/person/person.service';
import { Spinner } from '../../shared/components/spinner/spinner';

@Component({
  selector: 'app-home',
  imports: [VaccinationCard, PersonModal, Spinner],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  people: GetPersonsItemDto[] = [];

  selectedPersonId: string | null = null;

  showRegisterPersonModal: boolean = false;
  isLoading = signal(false);

  constructor(private personService: PersonService) {}

  ngOnInit() {
    this.loadPersons();
  }

  loadPersons() {
    this.isLoading.set(true);
      
    this.personService.getAll().subscribe({
      next: (data) => {
        this.people = data;
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Fetch failed', err);
        this.isLoading.set(false);
      }
    });
  }

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
