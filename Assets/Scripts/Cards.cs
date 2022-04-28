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
    public bool selectedCard = false;

    public void SetCardTaken()
    {
        if (takenCard)
        {
            takenCard = false;
        }
        else
        {
            takenCard = true;
        }
    }

    public void SetCardSelected()
    {
        if (selectedCard)
        {
            selectedCard = false;
        }
        else
        {
            selectedCard = true;
        }
    }
}
