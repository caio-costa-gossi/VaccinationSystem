import { Component, EventEmitter, Input, OnChanges, OnInit, Output, signal, SimpleChanges } from '@angular/core';
import { GetPersonDto } from '../../../api/person/person.type';
import { GetVaccinationDto } from '../../../api/vaccination/vaccination.type';
import { NewVaccination, VaccinationRegisterModal } from '../../../shared/components/vaccination-register-modal/vaccination-register-modal';
import { ConfirmModal } from '../../../shared/components/confirm-modal/confirm-modal';
import { DoseManagementDto, DoseManagementModal } from '../../../shared/components/dose-management-modal/dose-management-modal';
import { PersonService } from '../../../api/person/person.service';
import { Spinner } from '../../../shared/components/spinner/spinner';
import { VaccinationService } from '../../../api/vaccination/vaccination.service';

type Dose = {
    vaccinationId: string;
    doseNumber: number;
    appliedAt: string;
};

type Vaccination = {
  vaccineId: string;
  vaccineName: string;
  appliedDoses: Dose[];
};

@Component({
  selector: 'app-vaccination-card',
  imports: [VaccinationRegisterModal, ConfirmModal, DoseManagementModal, Spinner],
  templateUrl: './vaccination-card.html',
  styleUrl: './vaccination-card.css',
})
export class VaccinationCard implements OnInit, OnChanges {
  @Input() personId!: string;
  @Output() personDeleted = new EventEmitter<void>();

  person: GetPersonDto = {id: '', name: '', vaccinations: []};
  vaccinations: Vaccination[] = [];

  selectedDose: DoseManagementDto | null = null;

  showDeletePersonModal: boolean = false;
  showRegisterVaccinationModal: boolean = false;
  showDoseManagementModal: boolean = false;

  isLoading = signal(false);

  constructor(
    private personService: PersonService,
    private vaccinationService: VaccinationService
  ) {}

  ngOnInit(): void {
    this.loadPerson();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['personId']) {
      this.loadPerson();
    }
  }

  loadPerson() {
    this.isLoading.set(true);
      
    this.personService.getById(this.personId).subscribe({
      next: (data) => {
        this.person = data;
        this.vaccinations = this.mapVaccinations(this.person.vaccinations);
        this.vaccinations.forEach(v => v.appliedDoses.sort((a,b) => a.doseNumber - b.doseNumber));

        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Fetch failed', err);
        this.isLoading.set(false);
      }
    });
  }

  onDeletePerson() {
    this.showDeletePersonModal = true;
  }

  onConfirmDeletion(confirm: boolean) {
    this.showDeletePersonModal = false;
    
    if (!confirm)
      return;
    
    this.personService.delete(this.personId).subscribe({
      next: (data) => {
        this.isLoading.set(false);
        this.personDeleted.emit();
      },
      error: (err) => {
        console.error('Delete failed', err);
        this.isLoading.set(false);
      }
    });
  }

  onRegisterVaccination() {
    this.showRegisterVaccinationModal = true;
  }

  onConfirmRegisterVaccination(newVaccination: NewVaccination) {
    this.vaccinationService.create(
      this.personId,
      newVaccination.vaccineId,
      newVaccination.doseNumber,
      newVaccination.applicationDate
    ).subscribe({
      next: (data) => {
        this.loadPerson();
      },
      error: (err) => {
        console.error('Post failed', err);
        this.isLoading.set(false);
      }
    });
  }

  onDoseClick(dose: Dose, vaccineName: string) {
    this.selectedDose = {
      vaccineName: vaccineName,
      vaccinationId: dose.vaccinationId, 
      doseNumber: dose.doseNumber, 
      appliedAt: dose.appliedAt
    };

    this.showDoseManagementModal = true;
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
