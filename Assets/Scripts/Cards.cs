using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public int cardNumber;
    public enum CardSuit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
        Joker
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
            transform.Translate(transform.up * -0.2f);
        }
        else
        {
            selectedCard = true;
            transform.Translate(transform.up * 0.2f);
        }
    }

    public bool JokerCardFinder()
    {
        if (Suit == CardSuit.Joker)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
