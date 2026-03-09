import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Team } from '../models/team-list.model';

@Injectable({
  providedIn: 'root'
})
export class TeamService {

  private readonly baseUrl = 'https://api.nhle.com/stats/rest/en/team';

  constructor(private http: HttpClient) { }

  getAllTeams(): Observable<Team[]> {
    return this.http.get<any>(this.baseUrl).pipe(
      map(response =>
        response.data.map((t: any) => ({
          id: t.id,
          fullName: t.fullName,
          abbreviation: t.triCode
        }))
      )
    );
  }
}
