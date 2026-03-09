import { Component, OnInit } from '@angular/core';
import { SeasonService } from '../../services/season-list.service';
import { TeamService } from '../../services/team-list.service';
import { FormControl,ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { startWith, map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Team } from '../../models/team-list.model';
import { Season } from '../../models/season-list.model';


@Component({
  selector: 'app-player-stats',
  standalone: true,
  imports: [CommonModule, MatAutocompleteModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  templateUrl: './player-stats.component.html',
})

export class PlayerStatsComponent implements OnInit {
  seasons: Season[] = []; // e.g., ["2025-2026", "2024-2025"]
  players: any[] = [];    // your player objects
  teams: Team[] = [];      // your team objects

  seasonControl = new FormControl('');
  teamControl = new FormControl('');

  filteredSeasons: Season[] = [];
  filteredTeams: any[] = [];

  selectedSeason!: string;
  selectedTeam!: string;

  constructor(private SeasonService: SeasonService, private teamService: TeamService) { }

  ngOnInit(): void {

    this.SeasonService.getAllSeasons().subscribe(seasons => {
      this.seasons = seasons;
      this.filteredSeasons = seasons;
    });
    this.teamService.getAllTeams().subscribe(teams => {
      this.teams = teams;
      this.filteredTeams = teams;
    });
  }

  filterSeasons(value: string | Season) {
    const filterValue =
      typeof value === 'string'
        ? value
        : value.id.toString();

    this.filteredSeasons = this.seasons.filter(s =>
      s.id.toString().includes(filterValue)
    );
  }

  filterTeams(value: string) {
    const filterValue = value.toLowerCase();
    this.filteredTeams = this.teams.filter(t =>
      t.fullName.toLowerCase().includes(filterValue)
    );
  }
}
