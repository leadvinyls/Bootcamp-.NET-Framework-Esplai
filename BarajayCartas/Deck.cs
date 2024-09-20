using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DeckAndCards
{
    public class Deck
    {
        List<Card> cards;

        public Deck(bool? empty = false)
        {
            cards = new List<Card>();
            if (empty != null)
            {
                for (int n = 1; n <= 12; n++)
                    foreach (ESuit palo in Enum.GetValues(typeof(ESuit)))
                        cards.Add(new Card(n, palo));

            }
        }

        public List<Card> Cards { get { return cards; } set { cards = value; } }

        public override string ToString()
        {
            string sOut = "";
            foreach (Card card in this.cards)
                sOut += $"{card} .{this.cards.IndexOf(card) + 1}\n";

            return sOut;
        }

        public void AddCard(Card newCard)
        {
            cards.Add(newCard);
        }

        public Card DrawCard() 
        {
            Card drewCard = cards[0];
            cards.Remove(drewCard);
            return drewCard;
        }

        public void Shuffle()
        {
            List<Card> shuffledCards = new List<Card>();
            Random rnd = new Random();

            while (this.cards.Count() != 0)
            {
                int index = rnd.Next(0, this.cards.Count());
                Card currentCard = this.cards[index];
                shuffledCards.Add(currentCard);
                this.cards.Remove(currentCard);
            }

            this.cards = shuffledCards;
        }

        public Card DrawCardN(int n)
        {
            Card card = this.cards[n];
            this.cards.RemoveAt(n);
            return card;
        }

        public Card DrawRandomCard()
        {
            Random rnd = new Random();
            int cardNum = rnd.Next(0, this.cards.Count());
            return this.DrawCardN(cardNum);
        }

        public int CardsCount() 
        {
            return this.Cards.Count();
        }

        public int InputCard()
        {
            int num;

            do
            {
                num = InputTools.IntroNum();
            } while (num < 0 && num > CardsCount());

            return num - 1;
        }
    }
}
