import { inject, Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { LoginResponseDto } from './auth.type';
import { Observable } from 'rxjs';

@Service()
export class AuthService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  login(username: string, password: string): Observable<LoginResponseDto> {
    return this.http.post<LoginResponseDto>(`${this.baseUrl}/auth/login`, {
      name: username,
      password: password
    });
  } 

  register(username: string, password: string) {
    return this.http.post(`${this.baseUrl}/auth/register`, {
      name: username,
      password: password
    });
  } 
}