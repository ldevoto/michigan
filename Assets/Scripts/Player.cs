using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour
    {
        public Deck personalDeck;
        public Transform handPosition;
        private List<Card> hand = new List<Card>();
        private float angle = 45f;
        private float distance = 0.075f;

        public void SetHand(List<Card> cards)
        {
            hand.AddRange(cards);
            foreach (var card in cards)
            {
                card.MoveTo(handPosition);
                card.FlipUp();
            }
            DistributeHandEasy();
        }

        public void DistributeHandEasy()
        {
            var initPosition = -(hand.Count - 1) * distance / 2;
            foreach (var card in hand)
            {
                card.MoveTo(new Vector3(initPosition, 0, 0));
                initPosition += distance;
            }
        }

        public void DistributeHand()
        {
            var initAngle = -angle;
            var difference = hand.Count != 1 ? angle * 2 / (hand.Count - 1) : initAngle;
            if (hand.Count % 2 == 1)
            {
                //initAngle += difference;
            }
            foreach (var card in hand)
            {
                card.RotateTo(initAngle, transform.TransformVector(new Vector3(0, 0, -0.5f)));
                initAngle += difference;
            }
        }

        public void SetPersonalDeck(List<Card> cards)
        {
            personalDeck.Join(Deck.CreateDeckWith(cards));
            personalDeck.AlignTop();
            personalDeck.FlipFirst();
        }
    }
}