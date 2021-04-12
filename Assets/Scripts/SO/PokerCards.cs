using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "PokerCards", menuName = "SO/PokerCards", order = 0)]
    public class PokerCards : ScriptableObject
    {
        [Header("Black Deck")]
        public GameObject[] black_club;
        public GameObject[] black_diamond;
        public GameObject[] black_heart;
        public GameObject[] black_spade;
        public GameObject black_joker;
        public GameObject black_blank;
        
        [Header("Blue Deck")]
        public GameObject[] blue_club;
        public GameObject[] blue_diamond;
        public GameObject[] blue_heart;
        public GameObject[] blue_spade;
        public GameObject blue_joker;
        public GameObject blue_blank;
        
        [Header("Red Deck")]
        public GameObject[] red_club;
        public GameObject[] red_diamond;
        public GameObject[] red_heart;
        public GameObject[] red_spade;
        public GameObject red_joker;
        public GameObject red_blank;
        
        public Deck GenerateBlackDeck() 
        {
            var deck = Deck.CreateEmptyDeck();
            GenerateSuit(deck, Suit.CLUB, black_club);
            GenerateSuit(deck, Suit.DIAMOND, black_diamond);
            GenerateSuit(deck, Suit.HEART, black_heart);
            GenerateSuit(deck, Suit.SPADE, black_spade);
            GenerateJokers(deck, black_joker);
            return deck;
        }
        
        public Deck GenerateBlueDeck() 
        {
            var deck = Deck.CreateEmptyDeck();
            GenerateSuit(deck, Suit.CLUB, blue_club);
            GenerateSuit(deck, Suit.DIAMOND, blue_diamond);
            GenerateSuit(deck, Suit.HEART, blue_heart);
            GenerateSuit(deck, Suit.SPADE, blue_spade);
            GenerateJokers(deck, blue_joker);
            return deck;
        }
        
        public Deck GenerateRedDeck() 
        {
            var deck = Deck.CreateEmptyDeck();
            GenerateSuit(deck, Suit.CLUB, red_club);
            GenerateSuit(deck, Suit.DIAMOND, red_diamond);
            GenerateSuit(deck, Suit.HEART, red_heart);
            GenerateSuit(deck, Suit.SPADE, red_spade);
            GenerateJokers(deck, red_joker);
            return deck;
        }
        
        private static void GenerateSuit(Deck deck, Suit suit, IReadOnlyList<GameObject> cards)
        {
            for (var i = 0; i < 13; i++)
            {
                var card = GenerateCard(cards[i]);
                card.number = (Number) i;
                card.suit = Suit.CLUB;
                deck.AddCard(card);
            }
        }
        
        private static void GenerateJokers(Deck deck, GameObject jokerPrefab)
        {
            for (var i = 0; i < 2; i++)
            {
                var card = GenerateCard(jokerPrefab);
                card.number = Number.JOKER;
                card.suit = Suit.JOKER;
                deck.AddCard(card);
            }
        }

        private static Card GenerateCard(GameObject cardPrefab)
        {
            return Instantiate(cardPrefab, Vector3.zero, Quaternion.identity).AddComponent<Card>();
        }
    }
}