import { inject, Service } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { GetVaccinesItemDto } from "./vaccine.type";

@Service()
export class VaccineService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getAll(): Observable<GetVaccinesItemDto[]> {
    return this.http.get<GetVaccinesItemDto[]>(`${this.baseUrl}/vaccines`);
  }

  create(name: string): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/vaccines`, {
        name: name
    });
  }

  delete(vaccineId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/vaccines/${vaccineId}`);
  }
}