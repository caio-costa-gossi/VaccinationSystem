import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-vaccination-card',
  imports: [],
  templateUrl: './vaccination-card.html',
  styleUrl: './vaccination-card.css',
})
export class VaccinationCard {
  @Input() person!: string;
}
