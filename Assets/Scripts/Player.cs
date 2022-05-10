using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] givenCards;

    public int cardLayoutX;
    public int cardLayoutY;
    public GameObject cardBack;

    public int playerCoins;
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

    public enum CardSuit
    {
        Clubs,
        Spades,
        Diamonds,
        Hearts
    }
    public CardSuit Suit;

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
                givenCards[i].transform.position = new Vector3(cardLayoutX * i, cardLayoutY, 0);
            }
        }
    }

    public void NewPlayerCoins(int c)
    {
        playerCoins += c;
    }

    public void ScoringTime()
    {
        //all cards same suit
        //set as royal flush
        //how many have the same number
        //set as thing
        //high card

        //THIS IS REALLY GROSS, BUT IT IS THE BEST I CAN DO RIGHT NOW
        //cardValue found
        int valueOne = givenCards[0].GetComponent<Cards>().cardNumber;
        int valueTwo = givenCards[1].GetComponent<Cards>().cardNumber;
        int valueThree = givenCards[2].GetComponent<Cards>().cardNumber;
        int valueFour = givenCards[3].GetComponent<Cards>().cardNumber;
        int valueFive = givenCards[4].GetComponent<Cards>().cardNumber;

        //cardSuit found
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Cards sn = gm.GetComponent<Cards>();
        int suitOne = sn.CardSuitFinder(givenCards[0]);
        int suitTwo = sn.CardSuitFinder(givenCards[1]);
        int suitThree = sn.CardSuitFinder(givenCards[2]);
        int suitFour = sn.CardSuitFinder(givenCards[3]);
        int suitFive = sn.CardSuitFinder(givenCards[4]);
    }
}