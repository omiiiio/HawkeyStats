namespace NHL.Api.Models.Players;

public class PlayerInfoDto
{

    //Basic Info
    public int PlayerId { get; set; }
    public string FullName { get; set; } = "";
    public string Position { get; set; } = "";
    public string Shoots { get; set; } = "";
    public string Team { get; set; } = "";


    //Bio info
    public int HeightInInches { get; set; }
    public int WeightInPounds { get; set; }
    public DateOnly BirthDate { get; set; }
    public string BirthPlace { get; set; } = "";

    public string HeadshotUrl { get; set; } = "";


    //Draftinfo
    public int? DraftYear { get; set; }
    public int? DraftRound { get; set; }
    public int? DraftOverallPick { get; set; }
    public string DraftedBy { get; set; } = "";
}