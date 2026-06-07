import { inject, Service } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';

@Service()
export class AuthService {
  private baseUrl = environment.apiUrl;
  private http = inject(HttpClient);

  login(username: string, password: string) {
    return this.http.post(`${this.baseUrl}/auth/login`, {
      name: username,
      password: password
    });
  } 
}