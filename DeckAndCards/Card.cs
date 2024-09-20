
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DeckAndCards
{
    public enum ESuit
    {
        Coins,
        Cups,
        Swords,
        Batons
    }

    public enum FSuit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }
    public class Card

    {
        public int Number { get; set; }
        public ESuit Suit { get; set; }

        public Card()
        {

        }
        public Card(int number, ESuit suit)
        {
            this.Number = number;
            this.Suit = suit;
        }

        public override string ToString() 
        {

            string sOut = " ___________________ \n"; 
            sOut += $"|";
            if (this.Number < 10)
                sOut += $" {this.Number}       ";
            else
            { 
                switch (this.Number)
                {
                    case 10:
                        sOut += " Jack    ";
                        break;
                    case 11:
                        sOut += " Knight  ";
                        break;
                    case 12:
                        sOut += " King    ";
                        break;
                }
            }

            sOut += "|";

            switch (this.Suit) 
            {
                case ESuit.Coins:
                    sOut += " Coins  ";
                    break;
                case ESuit.Cups:
                    sOut += " Cups   ";
                    break;
                case ESuit.Swords:
                    sOut += " Swords ";
                    break;
                case ESuit.Batons:
                    sOut += " Batons ";
                    break;
            }

            sOut += "|";
            

            return sOut; 
        }
    }
}
