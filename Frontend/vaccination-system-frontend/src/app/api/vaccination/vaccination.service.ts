import { inject, Service } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Service()
export class VaccinationService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  create(personId: string, vaccineId: string, doseNumber: number, applicationDate: string)
    : Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/persons/${personId}/vaccinations`, {
        vaccineId: vaccineId,
        doseNumber: doseNumber,
        applicationDate: applicationDate
    });
  }

  delete(personId: string, vaccinationId: string): Observable<void> {
    return this.http.delete<void>(
        `${this.baseUrl}/persons/${personId}/vaccinations/${vaccinationId}`
    );
  }
}