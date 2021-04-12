using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Deck: MonoBehaviour
    {
        public List<Card> cards = new List<Card>();
        private const int ShuffleCounts = 3;

        public static Deck CreateEmptyDeck()
        {
            var deck = new GameObject("deck");
            return deck.AddComponent<Deck>();
        }

        public static Deck CreateDeckWith(List<Card> cards)
        {
            var deck = CreateEmptyDeck();
            deck.AddAll(cards);
            return deck;
        }

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
            for (var i = Size()-1; i >= 0; i--)
            {
                var card = cards[i];
                card.MoveTo(offset);
                offset += new Vector3(0, 0.0002f, 0);
                card.FlipDown();
            }
        }

        public void MoveTo(Transform parent)
        {
            var thisTransform = transform;
            thisTransform.SetParent(parent);
            thisTransform.localPosition = Vector3.zero;
            thisTransform.localRotation = Quaternion.identity;
        }

        public void Join(Deck deck)
        {
            AddAll(deck.PickAllCards());
            deck.Destroy();
        }

        public int Size()
        {
            return cards.Count;
        }

        private void AddAll(IEnumerable<Card> cards)
        {
            foreach (var card in cards)
            {
                AddCard(card);
            }
        }

        private List<Card> PickAllCards()
        {
            return PickCards(Size());
        }

        public List<Card> PickCards(int n, bool justSee = false)
        {
            var pickedCards = new List<Card>();
            for (var i = 0; i < n; i++)
            {
                pickedCards.Add(PickCard(justSee));
            }
            return pickedCards;
        }
        
        public Card PickCard(bool justSee = false)
        {
            return PickCardAt(0, justSee);
        }

        public Card PickCardAt(int index, bool justSee = false)
        {
            var card = cards[index];
            if (!justSee)
            {
                cards.RemoveAt(index);
            }
            return card;
        }

        public void AddCard(Card card)
        {
            AddCardIn(card, Size());
        }

        public void AddCardIn(Card card, int index)
        {
            cards.Insert(index, card);
            card.transform.SetParent(transform);
        }

        public void FlipFirst()
        {
            var card = PickCard(true);
            card.FlipUp();
        }

        public void FlipLast()
        {
            var card = PickCard(true);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}