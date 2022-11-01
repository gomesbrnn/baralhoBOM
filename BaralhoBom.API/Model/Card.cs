using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BaralhoBom.API.Model
{
    public class Card
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string code { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }
}