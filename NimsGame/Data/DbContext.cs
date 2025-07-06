using Microsoft.EntityFrameworkCore;
using NimsGame.Domains;

namespace NimsGame.Data;

public class CountingGameContext : DbContext
{
    public CountingGameContext(DbContextOptions<CountingGameContext> options)
        : base(options)
    {
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<GameHistory> GameHistories { get; set; }
}
