import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Home } from './pages/home/home';
import { authGuard } from './core/guards/auth.guard';
import { Vaccines } from './pages/vaccines/vaccines';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: Login },
    { path: 'home', component: Home, canActivate: [authGuard] },
    { path: 'vaccines', component: Vaccines, canActivate: [authGuard] },
    { path: '**', redirectTo: 'home' }
];
