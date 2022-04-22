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

    public bool cardTaken = false;
    public GameObject[] allCards;

    void CheckAllCards()
    {
        allCards = GameObject.FindGameObjectsWithTag("Card");
    }
    ///taken cards check for later
    //bool TakenCardsCheck(t)
    //{
    //    allCards[t] = gameObject.GetComponenet<cardTaken>();
    //    if (cardTaken)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
