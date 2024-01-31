using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    public class Poker
    {
        public void PokerGame()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                List<Player> players = new List<Player>();
                for (int j = 0; j < n; j++)
                {
                    var cards = Console.ReadLine().Split(' ');
                    players.Add(new Player
                    {
                        Cards = new List<Card>
                        {
                           new Card { Value = cards[0].Substring(0, 1), Suit = cards[0].Substring(1, 1) },
                           new Card { Value = cards[1].Substring(0, 1), Suit = cards[1].Substring(1, 1) }
                        }
                    });
                }
                Dictionary<string, int> cardRanks = new Dictionary<string, int>()
                {
                      { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
                      { "7", 7 }, { "8", 8 }, { "9", 9 }, { "T", 10 },
                      { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 }
                };
                List<Card> deck = new List<Card>();
                string[] suits = { "S", "C", "H", "D" };
                string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
                foreach (var suit in suits)
                {
                    foreach (var value in values)
                    {
                        deck.Add(new Card { Value = value, Suit = suit });
                    }
                }
                for (int k = 0; k < n; k++)
                {
                    foreach (var card in players[k].Cards)
                    {
                        deck.Remove(deck.First(c => c.Value == card.Value && c.Suit == card.Suit));
                    }
                }

                List<List<Card>> winCombo = new List<List<Card>>();

                foreach (var card in deck)
                {
                    List<Card> playerCards = new List<Card>(players[0].Cards) { card };
                    var playerCardsGrouped = playerCards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).ThenByDescending(g => cardRanks[g.Key]).ToList();
                    int playerHighestRank = playerCardsGrouped[0].Count() == 3 ? 300 : playerCardsGrouped[0].Count() == 2 ? 200 : 100;
                    playerHighestRank += cardRanks[playerCardsGrouped[0].Key];

                    bool isWinning = true;
                    List<Player> winners = new List<Player> { players[0] };

                    foreach (var player in players.Skip(1))
                    {
                        List<Card> otherPlayerCards = new List<Card>(player.Cards) { card };
                        var otherPlayerCardsGrouped = otherPlayerCards.GroupBy(c => c.Value).OrderByDescending(g => g.Count()).ThenByDescending(g => cardRanks[g.Key]).ToList();
                        int otherPlayerHighestRank = otherPlayerCardsGrouped[0].Count() == 3 ? 300 : otherPlayerCardsGrouped[0].Count() == 2 ? 200 : 100;
                        otherPlayerHighestRank += cardRanks[otherPlayerCardsGrouped[0].Key];

                        if (otherPlayerHighestRank > playerHighestRank)
                        {
                            isWinning = false;
                            break;
                        }
                        else if (otherPlayerHighestRank == playerHighestRank)
                        {
                            winners.Add(player);
                        }
                    }

                    if (isWinning)
                    {
                        winCombo.Add(playerCards);
                    }
                }
            }

        }


    }
    public class Card
    {
        public string Value { get; set; }
        public string Suit { get; set; }
    }

    public class Player
    {
        public List<Card> Cards { get; set; }
    }
}
