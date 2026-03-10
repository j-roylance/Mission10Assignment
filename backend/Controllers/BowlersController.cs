// API controller that serves bowler data from the database

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10Assignment.Data;
using Mission10Assignment.Models;

namespace Mission10Assignment.Controllers;

[ApiController]
[Route("api/[controller]")]  // Base route: /api/Bowling
public class BowlingController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    // Inject the database context via dependency injection
    public BowlingController(BowlingLeagueContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET /api/Bowling - Returns all bowlers on the Marlins or Sharks teams
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Include(b => b.Team)  // Include Team so we can access TeamName
            .Where(b => b.Team != null && 
                (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))  // Filter to assignment teams only
            .Select(b => new  // Project to anonymous object for JSON response
            {
                b.BowlerID,
                FirstName = b.BowlerFirstName,
                MiddleName = b.BowlerMiddleInit,
                LastName = b.BowlerLastName,
                TeamName = b.Team!.TeamName,
                b.BowlerAddress,
                b.BowlerCity,
                b.BowlerState,
                b.BowlerZip,
                b.BowlerPhoneNumber
            })
            .ToListAsync();

        return Ok(bowlers);
    }
}