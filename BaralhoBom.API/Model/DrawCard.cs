using System.ComponentModel.DataAnnotations;

namespace BaralhoBom.API.Model
{
    public class DrawCard
    {
        [Key]
        public int Id { get; set; }
        public string deck_id { get; set; }
        public Card[] cards { get; set; }
    }
}