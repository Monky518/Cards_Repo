using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    public GameObject[] givenCards;

    public int cardLayoutX;
    public int cardLayoutY;
    public GameObject cardBack;

    public enum HandValue
    {
        HighCard,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
    public HandValue handValue;

    void Start()
    {
        FirstCards();
    }

    void FirstCards()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject gm = GameObject.FindGameObjectWithTag("GameManager");

            //calls random card method
            Rules sn = gm.GetComponent<Rules>();
            GameObject cat = sn.RandomCard();
            GameObject testingCard = cat;

            //sets the random card as part of the hand
            if (testingCard != null)
            {
                givenCards[i] = testingCard;
                testingCard = null;
                Instantiate(cardBack, new Vector2(cardLayoutX * i, cardLayoutY), Quaternion.identity);
            }
        }
    }

    public void ComputerAightBet()
    {
        //no more buttons
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules bs = gm.GetComponent<Rules>();
        bs.ResetButtonPosition();

        //finds handValue
        ScoringTime();

        //extra cards are drawn if any
        //finalscoringtime()
    }

    void ScoringTime()
    {
        //THIS IS REALLY GROSS, BUT IT IS THE BEST I CAN DO RIGHT NOW
        //cardValue found
        int valueOne = givenCards[0].GetComponent<Cards>().cardNumber;
        int valueTwo = givenCards[1].GetComponent<Cards>().cardNumber;
        int valueThree = givenCards[2].GetComponent<Cards>().cardNumber;
        int valueFour = givenCards[3].GetComponent<Cards>().cardNumber;
        int valueFive = givenCards[4].GetComponent<Cards>().cardNumber;

        //jokerCard found
        bool Joker = false;
        for (int i = 0; i < givenCards.Length; i++)
        {
            Cards sn = givenCards[i].GetComponent<Cards>();
            Joker = sn.JokerCardFinder();
            if (Joker)
            {
                break;
            }
        }

        //four
        //three (two)
        //two (another two)
        //high card
    }
}