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
        Spades
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

    public void CardSuitFinder(GameObject card)
    {
        int theTea;

        //checks card cardSuit

        if (Suit == CardSuit.Clubs)
        {
            theTea = 0;
            return theTea;
        }
        else if (Suit == CardSuit.Diamonds)
        {
            theTea = 1;
            return theTea;
        }
        else if (Suit == CardSuit.Hearts)
        {
            theTea = 2;
            return theTea;
        }
        else if (Suit == CardSuit.Spades)
        {
            theTea = 3;
            return theTea;
        }
        else
        {
            return null;
        }
    }
}
