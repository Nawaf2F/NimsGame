using NimsGame.Domains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimsGame.Domains
{
    public class GameHistory
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;

        public int LosingNumber { get; set; }

        public int MaxSteps { get; set; }

        public string Result { get; set; } = string.Empty;

        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }

        public int PlayerId { get; set; }
    }
}
