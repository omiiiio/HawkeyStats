import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PlayerInfo } from '../models/player-info.model';
import { PlayerStats } from '../models/player-stats.model';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private baseUrl = 'https://localhost:5001/api/players';

  constructor(private http: HttpClient) { }

  getPlayer(id: number): Observable<{ info: PlayerInfo; stats: PlayerStats }> {
    return this.http.get<{ info: PlayerInfo; stats: PlayerStats }>(
      `${this.baseUrl}/${id}`
    );
  }
}
