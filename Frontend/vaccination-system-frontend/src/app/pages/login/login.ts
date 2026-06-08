import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { firstValueFrom } from 'rxjs';
import { AuthService } from '../../api/auth/auth.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
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
    this.authService.login(this.username, this.password)
    .subscribe({
      next: (data) => {
        localStorage.setItem('token', data.accessToken);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        console.error('Post failed', err);

        if (err.error.message)
          alert(err.error.message);
      }
    });
  }
}
