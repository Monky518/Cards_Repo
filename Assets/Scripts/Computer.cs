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

    private bool Joker = false;

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
        for (int i = 0; i < givenCards.Length; i++)
        {
            Cards sn = givenCards[i].GetComponent<Cards>();
            Joker = sn.JokerCardFinder();
            if (Joker)
            {
                //do something?
            }
        }

        int hand = FourOfAKind();
        if (hand == 0)
        {
            //hand = ThreeOfAKind();
        }
        else if (hand == 1234)
        {
            handValue = HandValue.FourOfAKind;
            //set card 5 as selected
            Cards c = givenCards[4].GetComponent<Cards>();
            c.SetCardSelected();
            //run draw method in buttonscript
            GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
            ButtonScript bs = gm.GetComponent<ButtonScript>();
            //DOUBLE CHECK LATER
            //bs.DrawButton();
        }
        else if (hand == 1235)
        {
            handValue = HandValue.FourOfAKind;
            //set card 4 as selected
            //run draw method in buttonscript
        }
        else if (hand == 1245)
        {
            handValue = HandValue.FourOfAKind;
            //set card 3 as selected
            //run draw method in buttonscript
        }
        else if (hand == 1345)
        {
            handValue = HandValue.FourOfAKind;
            //set card 2 as selected
            //run draw method in buttonscript
        }
        else if (hand == 2345)
        {
            handValue = HandValue.FourOfAKind;
            //set card 1 as selected
            //run draw method in buttonscript
        }
        else if (hand == 12345)
        {
            handValue = HandValue.FiveOfAKind;
        }
        //three (two)
        //two (another two)
        //high card
    }

    int FourOfAKind()
    {
        //which cards are the four of a kind
        int cardPlacement = 0;
        bool fourOfAKind = false;
        if (givenCards[0] == givenCards[1] && givenCards[0] == givenCards[2] && givenCards[0] == givenCards[3])
        {
            cardPlacement = 1234;
            fourOfAKind = true;
        }
        else if (givenCards[0] == givenCards[1] && givenCards[0] == givenCards[2] && givenCards[0] == givenCards[4])
        {
            cardPlacement = 1235;
            fourOfAKind = true;
        }
        else if (givenCards[0] == givenCards[1] && givenCards[0] == givenCards[3] && givenCards[0] == givenCards[4])
        {
            cardPlacement = 1245;
            fourOfAKind = true;
        }
        else if (givenCards[0] == givenCards[2] && givenCards[0] == givenCards[3] && givenCards[0] == givenCards[4])
        {
            cardPlacement = 1345;
            fourOfAKind = true;
        }
        else if (givenCards[1] == givenCards[2] && givenCards[1] == givenCards[3] && givenCards[1] == givenCards[4])
        {
            cardPlacement = 2345;
            fourOfAKind = true;
        }

        if (fourOfAKind && Joker)
        {
            cardPlacement = 12345;
            return cardPlacement;
        }
        else
        {
            return cardPlacement;
        }
    }
}