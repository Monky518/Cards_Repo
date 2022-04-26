using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public int cardNumber;
    public enum CardSuit
    {
        Clubs,
        Spades,
        Diamonds,
        Hearts
    }
    public CardSuit Suit;
    public bool takenCard = false;
}
