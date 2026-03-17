// Model representing a bowler in the Bowling League database

namespace Mission10Assignment.Models;

public class Bowler
{
    public int BowlerID { get; set; }
    public string BowlerLastName { get; set; } = "";
    public string? BowlerFirstName { get; set; }
    public string? BowlerMiddleInit { get; set; }
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public string? BowlerPhoneNumber { get; set; }
    public int TeamID { get; set; }      // Foreign key to Teams table
    public Team? Team { get; set; }       // Navigation property to the bowler's team
}