using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10Assignment.Data;
using Mission10Assignment.Models;

namespace Mission10Assignment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BowlingController : ControllerBase
{
    private readonly BowlingLeagueContext _context;

    public BowlingController(BowlingLeagueContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetBowlers()
    {
        var bowlers = await _context.Bowlers
            .Include(b => b.Team)
            .Where(b => b.Team != null && 
                (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))
            .Select(b => new
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