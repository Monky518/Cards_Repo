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
    public int ScoringTime(GameObject[] t)
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

        //checks for cardPlacement and handValue, manual by meeeeee
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
        return hand;
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
            if(valueOne == valueFive)
            {
                cp = 150234;
            }
            else if(valueOne == valueFour)
            {
                cp = 140235;
            }
            else if(valueOne == valueThree)
            {
                cp = 130245;
            }
        }
        else if (cp > 100)
        {
            if(valueFour == valueFive)
            {
                cp = 450123;
            }
            else if(valueThree == valueFive)
            {
                cp = 350124;
            }
            else if(valueThree == valueFour)
            {
                cp = 340125;
            }
            else if(valueTwo == valueFive)
            {
                cp = 250134;
            }
            else if(valueTwo == valueFour)
            {
                cp = 240135;
            }
            else if(valueTwo == valueThree)
            {
                cp = 230145;
            }
        }
        else
        {
            cp = 0;
        }
        return cp;
    }

    void ThreeOfAKindFind(int hand)
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
        //checks for fullhouse or not
        if (hand > 100000)
        {
            //good hand so nothing needs drawn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
        else
        {
            if (hand == 123)
            {
                Cards c1 = givenCards[4].GetComponent<Cards>();
                Cards c2 = givenCards[5].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 124)
            {
                Cards c1 = givenCards[3].GetComponent<Cards>();
                Cards c2 = givenCards[5].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 125)
            {
                Cards c1 = givenCards[3].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 134)
            {
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[5].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 135)
            {
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 145)
            {
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 234)
            {
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[5].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 245)
            {
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (hand == 345)
            {
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            //new card!
            GameObject comp = GameObject.FindGameObjectWithTag("Computer");
            Computer rc = comp.GetComponent<Computer>();
            rc.RedrawCards();
            //end turn
            Rules r = gm.GetComponent<Rules>();
            r.FinalScoringTime();
        }
    }

    int Pair()
    {
        int cardPlacement = 0;
        bool pair = false;
        //checks for every single possible pair
        if (valueOne == valueTwo)
        {
            cardPlacement = 12;
            pair = true;
        }
        else if (valueOne == valueThree)
        {
            cardPlacement = 13;
            pair = true;
        }
        else if (valueOne == valueFour)
        {
            cardPlacement = 14;
            pair = true;
        }
        else if (valueOne == valueFive)
        {
            cardPlacement = 15;
            pair = true;
        }
        else if (valueTwo == valueThree)
        {
            cardPlacement = 23;
            pair = true;
        }
        else if (valueTwo == valueFour)
        {
            cardPlacement = 24;
            pair = true;
        }
        else if (valueTwo == valueFive)
        {
            cardPlacement = 25;
            pair = true;
        }
        else if (valueThree == valueFour)
        {
            cardPlacement = 34;
            pair = true;
        }
        else if (valueThree == valueFive)
        {
            cardPlacement = 35;
            pair = true;
        }
        else if (valueFour == valueFive)
        {
            cardPlacement = 45;
            pair = true;
        }

        if (pair)
        {
            cardPlacement = TwoPairCheck(cardPlacement);
            if (Joker)
            {
                if (cardPlacement > 10)
                {
                    //set as full house with the Joker with the higher card
                }
                else
                {
                    //set as threeOfAKind
                    cardPlacement = cardPlacement * 10;
                    cardPlacement += jokerPlacement;
                }
            }
        }
        return cardPlacement;
    }

    int TwoPairCheck(int cp)
    {
        if (cp == 12)
        {
            //34 35 45
        }
        else if (cp == 13)
        {
            //24 25 45
        }
        else if (cp == 14)
        {
            //23 25 35
        }
        else if (cp == 15)
        {
            //23 24 34
        }
        else if (cp == 23)
        {
            //14 15 45
        }
        else if (cp == 24)
        {
            //13 15 35
        }
        else if (cp == 25)
        {
            //13 14 34
        }
        else if (cp == 34)
        {
            //12 15 25
        }
        else if (cp == 35)
        {
            //12 14 24
        }
        else if (cp == 45)
        {
            //12 13 23
        }
    }

    void PairFind()
    {

    }

    int HighCard()
    {

    }
}
