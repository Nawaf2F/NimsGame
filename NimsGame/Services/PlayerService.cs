using NimsGame.Domains;
using NimsGame.Data;
using Microsoft.EntityFrameworkCore;

namespace NimsGame.Services
{
    public class PlayerService
    {
        private readonly CountingGameContext _context;

        public PlayerService(CountingGameContext context)
        {
            _context = context;
        }

        public List<Player> GetAllPlayers()
        {
            return _context.Players
                .Include(p => p.History)
                .OrderByDescending(p => p.Wins)
                .ToList();
        }

        public Player? GetPlayer(string name)
        {
            return _context.Players
                .Include(p => p.History)
                .FirstOrDefault(p => p.Name == name);
        }

        public void AddOrUpdatePlayerWin(string name, int losingNumber, int maxSteps)
        {
            var player = GetPlayer(name);
            if (player == null)
            {
                player = new Player { Name = name };
                _context.Players.Add(player);
            }

            player.Wins++;
            player.History.Add(new GameHistory
            {
                LosingNumber = losingNumber,
                MaxSteps = maxSteps,
                Result = "Win",
                Player = player
            });

            _context.SaveChanges();
        }

        public void AddPlayerLoss(string name, int losingNumber, int maxSteps)
        {
            var player = GetPlayer(name);
            if (player == null)
            {
                player = new Player { Name = name };
                _context.Players.Add(player);
            }

            player.History.Add(new GameHistory
            {
                LosingNumber = losingNumber,
                MaxSteps = maxSteps,
                Result = "Loss",
                Player = player
            });

            _context.SaveChanges();
        }
    }
}
