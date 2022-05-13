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
    private GameObject gm;
    private int jokerPlacement;

    private int valueOne;
    private int valueTwo;
    private int valueThree;
    private int valueFour;
    private int valueFive;

    void Start()
    {
        FirstCards();
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    void FirstCards()
    {
        for (int i = 0; i < 5; i++)
        {
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
        valueOne = givenCards[0].GetComponent<Cards>().cardNumber;
        valueTwo = givenCards[1].GetComponent<Cards>().cardNumber;
        valueThree = givenCards[2].GetComponent<Cards>().cardNumber;
        valueFour = givenCards[3].GetComponent<Cards>().cardNumber;
        valueFive = givenCards[4].GetComponent<Cards>().cardNumber;

        //jokerCard found
        for (int i = 0; i < givenCards.Length; i++)
        {
            Cards sn = givenCards[i].GetComponent<Cards>();
            Joker = sn.JokerCardFinder();
            if (Joker)
            {
                jokerPlacement = i;
            }
        }

        //checks for four
        int hand = FourOfAKind();
        if (hand == 1234)
        {
            handValue = HandValue.FourOfAKind;
            //set card 5 as selected
            Cards c = givenCards[4].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1235)
        {
            handValue = HandValue.FourOfAKind;
            //set card 4 as selected
            Cards c = givenCards[3].GetComponent<Cards>();
            //new card!
            c.SetCardSelected();
            RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1245)
        {
            handValue = HandValue.FourOfAKind;
            //set card 3 as selected
            Cards c = givenCards[2].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1345)
        {
            handValue = HandValue.FourOfAKind;
            //set card 2 as selected
            Cards c = givenCards[1].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 2345)
        {
            handValue = HandValue.FourOfAKind;
            //set card 1 as selected
            Cards c = givenCards[0].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 12345)
        {
            handValue = HandValue.FiveOfAKind;
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 0)
        {
            hand = ThreeOfAKind();
        }
        //checks for three (two)
        //checks for two (another two)
        //finds high card
    }

    void RedrawCards()
    {
        Rules sn = gm.GetComponent<Rules>();
        for (int i = 0; i < givenCards.Length; i++)
        {
            //checks for see if any cards are selected
            bool b = givenCards[i].GetComponent<Cards>().selectedCard;
            if (b)
            {
                //resets location
                givenCards[i].transform.position = new Vector3(13.75f, 5, 0);
                //finds new card and places it
                givenCards[i] = sn.RandomCard();
                givenCards[i].transform.position = new Vector3(cardLayoutX * i, cardLayoutY, 0);
            }
        }
    }

    int FourOfAKind()
    {
        int cardPlacement = 0;
        bool fourOfAKind = false;
        if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFour)
        {
            cardPlacement = 1234;
            fourOfAKind = true;
        }
        else if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFive)
        {
            cardPlacement = 1235;
            fourOfAKind = true;
        }
        else if (valueOne == valueTwo && valueOne == valueFour && valueOne == valueFive)
        {
            cardPlacement = 1245;
            fourOfAKind = true;
        }
        else if (valueOne == valueThree && valueOne == valueFour && valueOne == valueFive)
        {
            cardPlacement = 1345;
            fourOfAKind = true;
        }
        else if (valueTwo == valueThree && valueTwo == valueFour && valueTwo == valueFive)
        {
            cardPlacement = 2345;
            fourOfAKind = true;
        }
        else
        {
            cardPlacement = 0;
        }

        //checks for Joker card before returning
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

    int ThreeOfAKind()
    {
        int cardPlacement = 0;
        bool threeOfAKind = false;
        if (valueOne == valueTwo && valueOne == valueThree)
        {
            cardPlacement = 123;
            threeOfAKind = true;
        }
        else if (valueOne == valueTwo && valueOne == valueFour)
        {
            cardPlacement = 124;
            threeOfAKind = true;
        }
        else if (valueOne == valueTwo && valueOne == valueFive)
        {
            cardPlacement = 125;
            threeOfAKind = true;
        }
        else if (valueOne == valueThree && valueOne == valueFour)
        {
            cardPlacement = 134;
            threeOfAKind = true;
        }
        else if (valueTwo == valueThree && valueTwo == valueFive)
        {
            cardPlacement = 135;
            threeOfAKind = true;
        }
        else if (valueOne == valueFour && valueOne == valueFive)
        {
            cardPlacement = 145;
            threeOfAKind = true;
        }
        else if (valueTwo == valueThree && valueTwo == valueFour)
        {
            cardPlacement = 234;
            threeOfAKind = true;
        }
        else if (valueTwo == valueThree && valueTwo == valueFive)
        {
            cardPlacement = 235;
            threeOfAKind = true;
        }
        else if (valueTwo == valueFour && valueTwo == valueFive)
        {
            cardPlacement = 245;
            threeOfAKind = true;
        }
        else if (valueThree == valueFour && valueThree == valueFive)
        {
            cardPlacement = 345;
            threeOfAKind = true;
        }
        else
        {
            cardPlacement = 0;
        }

        //check for joker and full house
        if (threeOfAKind && Joker)
        {
            cardPlacement = cardPlacement * 10;
            cardPlacement += jokerPlacement;
            return cardPlacement;
        }
        else if (threeOfAKind)
        {
            cardPlacement = FullHouseCheck(cardPlacement);
            return cardPlacement;
        }
        else
        {
            return cardPlacement;
        }
    }

    int FullHouseCheck(int cp)
    {
        if(cp > 300)
        {
            if(valueOne == valueTwo)
            {
                cp = 120345;
                return cp;
            }
            else
            {
                cp = 0;
                return cp;
            }
        }
        else if (cp > 200)
        {
            //234 235 245
            return cp;
        }
        else if (cp > 100)
        {
            //123 124 125 134 135 145\
            return cp;
        }
        else
        {
            cp = 0;
            return cp;
        }
    }
}