using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BaralhoBom.API.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Card> Cards { get; set; }
        public int Points { get; set; }

        public Player()
        {
            Name = Name;
            Cards = DrawFiveCards().Result;
            Points = SumPlayerPoints();
        }

        public async Task<Card[]> DrawFiveCards()
        {
            HttpClient httpClient = new();
            Cards = new Card[5];

            string endPoint = $"https://deckofcardsapi.com/api/deck/new/draw/?count=5";
            var response = await httpClient.GetAsync(endPoint);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<DrawCard>(content).cards;
        }

        private int ReturnCardValue(string cardValue)
        {
            if (cardValue == "ACE") return 1;
            else if (cardValue == "KING") return 13;
            else if (cardValue == "QUEEN") return 12;
            else if (cardValue == "JACK") return 11;

            return int.Parse(cardValue);
        }

        private int SumPlayerPoints()
        {
            int points = 0;

            foreach (Card card in Cards)
            {
                points += ReturnCardValue(card.value);
            }

            return points;
        }
    }
}