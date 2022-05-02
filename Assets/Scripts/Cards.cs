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

    public GameObject draw;
    public GameObject hold;

    void Start()
    {
        draw = GameObject.FindGameObjectWithTag("Draw");
        hold = GameObject.FindGameObjectWithTag("Hold");
    }
    
    void Update()
    {
        if (selectedCard)
        {
            if (hold)
            {
                hold.SetActive(false);
                draw.SetActive(true);
            }
        }
    }
    
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
            Debug.Log("no longer selected");
        }
        else
        {
            selectedCard = true;
            transform.Translate(transform.up * 0.2f);
            Debug.Log("selected card");
        }
    }
}
