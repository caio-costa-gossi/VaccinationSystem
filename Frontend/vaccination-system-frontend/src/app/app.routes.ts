import { Routes } from '@angular/router';
import { Login } from './pages/login/login';
import { Main } from './pages/main/main';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'login', component: Login },
    { path: 'home', component: Main },
    { path: '**', redirectTo: 'home' }
];
