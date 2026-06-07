import { Component } from '@angular/core';
import { VaccinationCard } from './vaccination-card/vaccination-card';

@Component({
  selector: 'app-main',
  imports: [VaccinationCard],
  templateUrl: './main.html',
  styleUrl: './main.css',
})
export class Main {
  people = ['Ana', 'Bruno', 'Carlos', 'Daniela'];
  selectedPerson: string | null = null;

  onSelect(event: EventTarget | null) {
    let htmlEvent = event as HTMLSelectElement;
    
    if (!htmlEvent)
      return;
    
    this.selectedPerson = htmlEvent.value;
  }
}
