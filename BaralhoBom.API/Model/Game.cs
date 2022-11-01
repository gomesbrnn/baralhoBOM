using System.Collections.Generic;

namespace BaralhoBom.API.Model
{
    public class Game
    {
        public int Id { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
        public string Winner { get; set; }
    }
}