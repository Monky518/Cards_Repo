using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
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

    public Sprite cardBack;
    public Sprite cardFront;

    void Start()
    {
        cardFront = transform.GetComponent<SpriteRenderer>().sprite;
    }
    
    public void ChangeAceScore()
    {
        if (cardNumber == 11)
        {
            cardNumber = 1;
        }
        else if (cardNumber == 1)
        {
            cardNumber = 11;
        }
    }

    public void FlipCard()
    {
        if (transform.GetComponent<SpriteRenderer>().sprite == cardBack)
        {
            transform.GetComponent<SpriteRenderer>().sprite = cardFront;
        }
        else if (transform.GetComponent<SpriteRenderer>().sprite == cardFront)
        {
            transform.GetComponent<SpriteRenderer>().sprite = cardBack;
        }
    }
}
