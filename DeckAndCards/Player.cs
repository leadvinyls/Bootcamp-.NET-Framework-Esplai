using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckAndCards
{
    public class Player
    {
        public string Name { get ; set ; }
        Deck playerDeck;

        public Deck PlayerDeck { get { return playerDeck; }}

        public Player()
        {
            playerDeck = new Deck(null);
        }
        public Player(string name) : this()
        {
            this.Name = name;
        }

        public Player(Player player) 
        {
            this.Name = player.Name;
            this.playerDeck = player.playerDeck;
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        public int CardsCount() 
        {
            return this.playerDeck.CardsCount();
        }

        public Card DrawCard()
        {
            return this.playerDeck.DrawCard();
        }

        public Card DrawCardN(int n)
        {
            return this.playerDeck.DrawCardN(n);
        }

        public Card DrawRandomCard()
        {
            return this.playerDeck.DrawRandomCard();
        }

        public void AddCard(Card card) 
        {
            this.playerDeck.AddCard(card);
        }
    }
}
