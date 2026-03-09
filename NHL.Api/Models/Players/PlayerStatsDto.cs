namespace NHL.Api.Models.Players;

public class PlayerStatsDto
{
	public int GamesPlayed { get; set; }
	public int Goals { get; set; }
	public int Assists { get; set; }
	public int Points { get; set; }

	public int Shots { get; set; }
	public int PlusMinus { get; set; }
	public int Pim { get; set; }

	public int PowerPlayGoals { get; set; }
	public int PowerPlayPoints { get; set; }

	public int ShorthandedGoals { get; set; }
	public int ShorthandedPoints { get; set; }

	public double ShootingPercentage { get; set; }
}