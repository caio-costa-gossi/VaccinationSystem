import { Component } from '@angular/core';
import { VaccinationCard } from './vaccination-card/vaccination-card';

@Component({
  selector: 'app-home',
  imports: [VaccinationCard],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  people = ['Ana', 'Bruno', 'Carlos', 'Daniela'];
  selectedPerson: string | null = null;

  onSelect(event: EventTarget | null) {
    let htmlEvent = event as HTMLSelectElement;
    
    if (!htmlEvent)
      return;
    
    this.selectedPerson = htmlEvent.value;
  }
}
