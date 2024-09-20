using DeckAndCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace DeckAndCards
{
    internal class BattleBoard
    {
        Dictionary<Player, Card> board;
        LinkedList<Player> activePlayers;
        LinkedList<Player> pasivePlayers;
        Deck mainDeck;
        public BattleBoard() 
        {
            board = new Dictionary<Player, Card>();
            activePlayers = new LinkedList<Player>();
            pasivePlayers = new LinkedList<Player>();
            mainDeck = new Deck();
        }
        public BattleBoard(int nPlayers)  : this()
        {
            for (int n = 1; n <= nPlayers; n++)
                activePlayers.AddLast(new Player($"Player {n}"));

            mainDeck.Shuffle();
        }

        private void ClearBoard() 
        {
            board = new Dictionary<Player, Card>();
        }
        public void PlayGame()
        {
            OutputTools.Clear();
            DealCards();

            Console.WriteLine("Cards are dealt");
            while (activePlayers.Count() >= 2)
            {
                foreach (var player in activePlayers)
                {
                    Console.WriteLine($"Turno: {player}\n{player.PlayerDeck}");
                    PlayCard(player);
                    CheckPlayerLoss();
                }
                CheckWinner();
                OutputTools.Clear();
            }

            Console.WriteLine($"The winner is: {activePlayers.First()}");
            pasivePlayers.AddFirst(activePlayers.First());

            Console.WriteLine("\nPodium\n");
            int position = 0;
            foreach (var player in pasivePlayers)
            {
                position++;
                Console.WriteLine($"{position}. {player.Name}");
            }
            Console.ReadKey();
        }

        private void DealCards()
        {
            while (mainDeck.CardsCount() > 0)
                foreach (Player player in activePlayers)
                    if (mainDeck.CardsCount() > 0)
                        player.AddCard(mainDeck.DrawCard());
        }

        private void PlayCard(Player player)
        {
            Card playedCard = player.DrawCard();
            board.Add(player, playedCard);
            OutputTools.Clear();
            Console.WriteLine($"{player} has played\n{playedCard}");
        }

        private void CheckPlayerLoss()
        {
            LinkedList<Player> aux = new LinkedList<Player>(activePlayers);
            foreach (var player in activePlayers)
                if (player.CardsCount() <= 0)
                {
                    if (aux.Count() < 2)
                        return;

                    pasivePlayers.AddFirst(player);
                    aux.Remove(player);
                }

            activePlayers = aux;
        }

        private void CheckWinner()
        {
            KeyValuePair<Player, Card> graterPlay = board.First();
            Card graterCard = graterPlay.Value;
            foreach (var play in board)
            {
                Player currentPlayer = play.Key;
                Card currentCard = play.Value;
                if (currentCard.Number > graterCard.Number || (currentCard.Number == graterCard.Number && currentCard.Suit < graterCard.Suit))
                    graterPlay = new KeyValuePair<Player, Card>(currentPlayer, currentCard);
            }

            /*Player winner = graterPlay.Key;
            foreach (var card in board.Values)
                winner.AddCard(card);*/

            ClearBoard();
        }
    }
}
