import { Routes } from '@angular/router';
import { PlayerStatsComponent } from './pages/player-stats/player-stats.component';

export const routes: Routes = [
  { path: 'players', component: PlayerStatsComponent },
  { path: '', redirectTo: 'players', pathMatch: 'full' }
];
