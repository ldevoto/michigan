using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        private const int ShuffleCounts = 3;

        public void Shuffle()
        {
            for (var i = 0; i < ShuffleCounts; i++)
            {
                OneRoundShuffle();
            }
        }

        private void OneRoundShuffle()
        {
            var takenCards = new List<Card>();
            var size = Size();
            for (var i = 0; i < size; i++)
            {
                takenCards.Add(PickCardAt(Random.Range(0, Size())));
            }
            AddAll(takenCards);
        }

        public void Align()
        {
            var offset = Vector3.zero;
            var count = 0;
            foreach (var card in cards)
            {
                card.transform.position += offset;
                offset += new Vector3(0.1f, 0 , 0);
                count++;
                
                if (count < 12) continue;
                count = 0;
                offset.x = 0;
                offset.z += 0.1f;
            }
        }

        public void AlignTop()
        {
            var offset = Vector3.zero;
            foreach (var card in cards)
            {
                card.transform.position = offset;
                offset += new Vector3(0, 0.0002f, 0);
                card.FlipDown();
            }
        }

        public void Join(Deck deck)
        {
            AddAll(deck.GetAllCards());
        }

        public int Size()
        {
            return cards.Count;
        }

        private void AddAll(IEnumerable<Card> cards)
        {
            this.cards.AddRange(cards);
        }

        private IEnumerable<Card> GetAllCards()
        {
            return cards;
        }

        public Card PickCard()
        {
            return PickCardAt(0);
        }

        public List<Card> PickCards(int n)
        {
            var pickedCards = new List<Card>();
            for (var i = 0; i < n; i++)
            {
                pickedCards.Add(PickCard());
            }
            return pickedCards;
        }

        public Card PickCardAt(int index)
        {
            var card = cards[index];
            cards.RemoveAt(index);
            return card;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void AddCardIn(Card card, int index)
        {
            cards.Insert(index, card);
        }
    }
}