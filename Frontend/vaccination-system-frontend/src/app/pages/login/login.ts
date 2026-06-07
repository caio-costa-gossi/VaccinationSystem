import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { AuthService } from '../../api/auth/auth.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {}
  
  async submit() {
    try {
      const res: any = await firstValueFrom(
        this.authService.login(this.username, this.password)
      );

      localStorage.setItem('token', res.accessToken);
      this.router.navigate(['/home']);

    } 
    catch (err) {
      console.error('Login failed', err);
    }
  }
}
