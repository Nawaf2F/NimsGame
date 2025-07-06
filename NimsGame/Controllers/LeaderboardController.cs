using Microsoft.AspNetCore.Mvc;
using NimsGame.Services;

namespace NimsGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public LeaderboardController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public IActionResult GetLeaderboard()
        {
            var players = _playerService.GetAllPlayers();
            return Ok(players);
        }

        [HttpGet("{name}")]
        public IActionResult GetPlayer(string name)
        {
            var player = _playerService.GetPlayer(name);
            if (player == null)
                return NotFound($"Player '{name}' not found.");

            return Ok(player);
        }

        [HttpPost("win")]
        public IActionResult AddWin([FromBody] GameRecordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Player name is required.");

            _playerService.AddOrUpdatePlayerWin(request.Name, request.LosingNumber, request.MaxSteps);
            return Ok(new { message = $"{request.Name}'s win recorded." });
        }

        [HttpPost("loss")]
        public IActionResult AddLoss([FromBody] GameRecordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest("Player name is required.");

            _playerService.AddPlayerLoss(request.Name, request.LosingNumber, request.MaxSteps);
            return Ok(new { message = $"{request.Name}'s loss recorded." });
        }
    }

    public class GameRecordRequest
    {
        public string Name { get; set; } = string.Empty;
        public int LosingNumber { get; set; }
        public int MaxSteps { get; set; }
    }
}
