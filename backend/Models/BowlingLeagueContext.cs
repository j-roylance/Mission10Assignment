// Entity Framework DbContext - connects to the Bowling League SQLite database

using Microsoft.EntityFrameworkCore;
using Mission10Assignment.Models;

namespace Mission10Assignment.Data;

public class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options) { }

    // DbSets represent the tables we can query
    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }
}