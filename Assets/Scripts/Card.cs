using UnityEngine;

namespace DefaultNamespace
{
    public class Card: MonoBehaviour
    {
        public Number number;
        public Suit suit;

        public void FlipDown()
        {
            transform.localRotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        
        public void FlipUp()
        {
            transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);
        }

        public void MoveTo(Vector3 newPosition)
        {
            transform.localPosition = newPosition;
        }

        public void RotateTo(float angle, Vector3 vector3)
        {
            transform.rotation = Quaternion.identity;
            transform.RotateAround(new Vector3(0, 0, -0.1f), new Vector3(0, 1f, 0), angle);
        }
    }

    public enum Number
    {
        AS, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, J, Q, K, JOKER
    }

    public enum Suit
    {
        CLUB, DIAMOND, HEART, SPADE, JOKER
    }
}