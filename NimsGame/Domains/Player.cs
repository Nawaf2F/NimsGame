using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimsGame.Domains
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Wins { get; set; }

        public List<GameHistory> History { get; set; } = new List<GameHistory>();
    }
}
