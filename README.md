# HawkeyStats

This document's purpose is to guide the user in the use of the HawkeyStats app.

## Table of Contents

# Hawkey Stats Documentation

## Current Features

## API

## leagueService.cs

This service contains the functions to get data regarding the NHL league.

### getStandingsNowAsync
* Method: Task
* Input: None
* Output:

## playerService.cs

This service contains the functions to get data regarding NHL players.

### GetplayerInfoAsync
* Purpose: Gets personal info of player. (Name, team, position, bio info, draft info)
* Method: Task
* Input: playerID (INT)
* Output: PlayerInfoDto

### GetPlayerCareerStatsAsync
* Purpose: Retrieves a player's career seasons stats. 
* Method: Task
* Input: playerID (INT)
* Output: PlayerStatsDto

### GetPlayerCareerPlayoffStatsAsync
* Purpose: Retrieves a player's carreer stats for playoffs. 
* Method: Task
* Input: playerID (INT)
* Output: PlayerStatsDto

### teamService.cs

This service contains the functions to get data regarding NHL teams.

### getTeamSeasonsAsync
* Purpose: Retrieve a list of all the season IDS the team has. 
* Method: Task
* Input: teamID (INT)
* Output: 

### getTeamRosterAsync
* Purpose: Retrieve current roster of a team.
* Method: Task
* Input: teamID (INT)
* Output:
  
### getTeamScheduleNowWeekAsync
* Purpose: Retrieve the scheudle of a team for the current week.
* Method: Task
* Input: teamID (INT)
* Output: 

### getTeamStatsSeasonAsync
* Purpose: Retrieve the stats of a team for the current season. 
* Method: Task
* Input: teamID (INT)
* Output: 


