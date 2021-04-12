using SO;
using UnityEngine;

namespace DefaultNamespace
{
    public class MichiganController : MonoBehaviour
    {
        public PokerCards pokerCards;
        public Player[] players;
        public int handCardsCount = 5;
        public int personalDeckCardsCount = 10;
        public Deck mainDeck;

        public void Start()
        {
            mainDeck.Join(pokerCards.GenerateBlueDeck());
            //mainDeck.Join(pokerCards.GenerateBlackDeck());
            mainDeck.Join(pokerCards.GenerateRedDeck());
            mainDeck.Shuffle();
            mainDeck.AlignTop();

            StartGame();
        }

        private void StartGame()
        {
            foreach (var player in players)
            {
                player.SetPersonalDeck(mainDeck.PickCards(personalDeckCardsCount));
                player.SetHand(mainDeck.PickCards(handCardsCount));
            }
        }
    }
}