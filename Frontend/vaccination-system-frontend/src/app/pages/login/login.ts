import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../core/services/auth/auth.service';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

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
    console.log('Hello login!');
    console.log(this.username);
    console.log(this.password);

    try {
      const res: any = await firstValueFrom(
        this.authService.login(this.username, this.password)
      );

      localStorage.setItem('token', res.token);
      this.router.navigate(['/main']);

    } 
    catch (err) {
      console.error('Login failed', err);
    }
  }
}
