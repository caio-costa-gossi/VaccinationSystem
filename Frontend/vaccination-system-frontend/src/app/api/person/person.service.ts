import { inject, Service } from "@angular/core";
import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { GetPersonDto, GetPersonsItemDto } from "./person.type";

@Service()
export class PersonService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  getAll(): Observable<GetPersonsItemDto[]> {
    return this.http.get<GetPersonsItemDto[]>(`${this.baseUrl}/persons`);
  } 

  getById(id: string): Observable<GetPersonDto> {
    return this.http.get<GetPersonDto>(`${this.baseUrl}/persons/${id}`);
  }

  create(name: string): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/persons`, {
        name: name
    });
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/persons/${id}`);
  }
}