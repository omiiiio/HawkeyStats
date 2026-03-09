import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { Season } from '../models/season-list.model';

@Injectable({
  providedIn: 'root'
})
export class SeasonService {

  private readonly baseUrl = 'https://api-web.nhle.com/v1/season';

  constructor(private http: HttpClient) { }

  getAllSeasons(): Observable<Season[]> {
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
