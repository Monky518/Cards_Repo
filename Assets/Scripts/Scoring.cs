using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private int valueOne;
    private int valueTwo;
    private int valueThree;
    private int valueFour;
    private int valueFive;

    private GameObject gm;

    private bool Joker = false;
    private int jokerPlacement;

    private enum HandValue
    {
        HighCard,
        Pair,
        TwoPairs,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
    private HandValue handValue;

    private GameObject[] givenCards;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");

        //checks for three (two)
        //checks for two (another two)
        //finds high card
    }

    //will return GameObjects of unused cards
    public GameObject[] ScoringTime(GameObject[] t)
    {
        givenCards = t;
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
        if (hand == 0)
        {
            hand = ThreeOfAKind();
            if (hand == 0)
            {
                hand = Pair();
                if (hand == 0)
                {
                    hand = HighCard();
                    //redraw the entire hand if high card != ace
                    //otherwise save that card and redraw everything else
                }
                else
                {
                    PairFind(hand);
                }
            }
            else
            {
                ThreeOfAKindFind(hand);
            }
        }
        else
        {
            FourOfAKindFind(hand);
        }
    }

    int FourOfAKind()
    {
        int cardPlacement = 0;
        bool fourOfAKind = false;
        //checks for every single possible four of a kind
        if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFour)
        {
            cardPlacement = 1234;
            fourOfAKind = true;
            handValue = HandValue.FourOfAKind;
        }
        else if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFive)
        {
            cardPlacement = 1235;
            fourOfAKind = true;
            handValue = HandValue.FourOfAKind;
        }
        else if (valueOne == valueTwo && valueOne == valueFour && valueOne == valueFive)
        {
            cardPlacement = 1245;
            fourOfAKind = true;
            handValue = HandValue.FourOfAKind;
        }
        else if (valueOne == valueThree && valueOne == valueFour && valueOne == valueFive)
        {
            cardPlacement = 1345;
            fourOfAKind = true;
            handValue = HandValue.FourOfAKind;
        }
        else if (valueTwo == valueThree && valueTwo == valueFour && valueTwo == valueFive)
        {
            cardPlacement = 2345;
            fourOfAKind = true;
            handValue = HandValue.FourOfAKind;
        }
        else
        {
            cardPlacement = 0;
        }

        //checks for Joker card before returning
        if (fourOfAKind && Joker)
        {
            cardPlacement = 12345;
            handValue = HandValue.FiveOfAKind;
        }
        return cardPlacement;
    }

    void FourOfAKindFind(int hand)
    {
        if (hand == 1234)
        {
            //set card 5 as selected
            Cards c = givenCards[4].GetComponent<Cards>();
            //new card!
            c.SetCardSelected();
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1235)
        {
            //set card 4 as selected
            Cards c = givenCards[3].GetComponent<Cards>();
            //new card!
            c.SetCardSelected();
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1245)
        {
            //set card 3 as selected
            Cards c = givenCards[2].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 1345)
        {
            //set card 2 as selected
            Cards c = givenCards[1].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 2345)
        {
            //set card 1 as selected
            Cards c = givenCards[0].GetComponent<Cards>();
            c.SetCardSelected();
            //new card!
            c.SetCardSelected();
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else if (hand == 12345)
        {
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
    }

    int ThreeOfAKind()
    {
        int cardPlacement = 0;
        bool threeOfAKind = false;
        //checks for every single possible three of a kind
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
        }
        else if (threeOfAKind)
        {
            cardPlacement = FullHouseCheck(cardPlacement);
        }
        return cardPlacement;
    }

    int FullHouseCheck(int cp)
    {
        //using the three of a kind card placement, find if the other two are a pair
        if (cp > 300)
        {
            if (valueOne == valueTwo)
            {
                cp = 120345;
            }
        }
        else if (cp > 200)
        {
            //234 235 245
        }
        else if (cp > 100)
        {
            //123 124 125 134 135 145
        }
        else
        {
            cp = 0;
        }
        return cp;
    }

    void ThreeOfAKindFind()
    {

    }

    int Pair()
    {

    }

    int TwoPairCheck()
    {

    }

    void PairFind()
    {

    }

    int HighCard()
    {

    }
}
