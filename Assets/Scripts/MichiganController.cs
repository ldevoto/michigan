using SO;
using UnityEngine;

namespace DefaultNamespace
{
    public class MichiganController : MonoBehaviour
    {
        public PokerCards pokerCards;
        public Player[] players;
        public int handCardsCount = 5;
        private Deck deck;
        
        public void Start()
        {
            //var deck = pokerCards.GenerateBlackDeck();
            //deck.Join(pokerCards.GenerateBlueDeck());
            //deck.Join(pokerCards.GenerateRedDeck());
            //deck.Shuffle();
            //deck.Align();
            
            deck = pokerCards.GenerateBlueDeck();
            //deck.Join(pokerCards.GenerateBlackDeck());
            deck.Join(pokerCards.GenerateRedDeck());
            deck.Shuffle();
            deck.AlignTop();

            StartGame();
        }

        private void StartGame()
        {
            foreach (var player in players)
            {
                player.SetHand(deck.PickCards(handCardsCount));
            }
        }
    }
}