import { Component, signal } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../api/auth/auth.service';
import { Spinner } from '../../shared/components/spinner/spinner';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [FormsModule, Spinner],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  username = '';
  password = '';
  confirmPassword = '';

  isLoading = signal(false);

  constructor(
    private router: Router,
    private authService: AuthService) {}

  submit() {
    if (this.password !== this.confirmPassword) {
      alert('As senhas não coincidem.');
      return;
    }

    this.isLoading.set(true);
    
    this.authService.register(this.username, this.password).subscribe({
      next: (data) => {
        this.isLoading.set(false);
        this.router.navigate(['/login']);
      },
      error: (err) => {
        console.error('Post failed', err);
        this.isLoading.set(false);
      }
    });
  }
}
