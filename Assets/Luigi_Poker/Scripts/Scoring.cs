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
    private GameObject[] givenCards;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
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

        //checks for cardPlacement and handValue
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
                }
            }
        }
        return hand;
    }

    int FourOfAKind()
    {
        int cp = 0;
        //checks for every single possible four of a kind
        if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFour)
        {
            cp = 1234;
        }
        else if (valueOne == valueTwo && valueOne == valueThree && valueOne == valueFive)
        {
            cp = 1235;
        }
        else if (valueOne == valueTwo && valueOne == valueFour && valueOne == valueFive)
        {
            cp = 1245;
        }
        else if (valueOne == valueThree && valueOne == valueFour && valueOne == valueFive)
        {
            cp = 1345;
        }
        else if (valueTwo == valueThree && valueTwo == valueFour && valueTwo == valueFive)
        {
            cp = 2345;
        }
        else
        {
            cp = 0;
        }
        return cp;
    }

    int ThreeOfAKind()
    {
        int cp = 0;
        //checks for every single possible three of a kind
        if (valueOne == valueTwo && valueOne == valueThree)
        {
            cp = 123;
        }
        else if (valueOne == valueTwo && valueOne == valueFour)
        {
            cp = 124;
        }
        else if (valueOne == valueTwo && valueOne == valueFive)
        {
            cp = 125;
        }
        else if (valueOne == valueThree && valueOne == valueFour)
        {
            cp = 134;
        }
        else if (valueTwo == valueThree && valueTwo == valueFive)
        {
            cp = 135;
        }
        else if (valueOne == valueFour && valueOne == valueFive)
        {
            cp = 145;
        }
        else if (valueTwo == valueThree && valueTwo == valueFour)
        {
            cp = 234;
        }
        else if (valueTwo == valueThree && valueTwo == valueFive)
        {
            cp = 235;
        }
        else if (valueTwo == valueFour && valueTwo == valueFive)
        {
            cp = 245;
        }
        else if (valueThree == valueFour && valueThree == valueFive)
        {
            cp = 345;
        }
        else
        {
            cp = 0;
        }
        
        //check for full house
        if (cp != 0)
        {
            cp = FullHouseCheck(cp);
        }
        return cp;
    }

    int FullHouseCheck(int cp)
    {
        //using the three of a kind card placement, find if the other two are a pair
        if (cp == 123 && valueFour == valueFive)
        {
            cp = 123045;
        }
        else if (cp == 124 && valueThree == valueFive)
        {
            cp = 124035;
        }
        else if (cp == 125 && valueThree == valueFour)
        {
            cp = 125034;
        }
        else if (cp == 134 && valueTwo == valueFive)
        {
            cp = 134025;
        }
        else if (cp == 135 && valueTwo == valueFour)
        {
            cp = 135024;
        }
        else if (cp == 145 && valueTwo == valueThree)
        {
            cp = 145023;
        }
        else if (cp == 234 && valueOne == valueFive)
        {
            cp = 234015;
        }
        else if (cp == 235 && valueOne == valueFour)
        {
            cp = 235014;
        }
        else if (cp == 245 && valueOne == valueThree)
        {
            cp = 245013;
        }
        else if (cp == 345 && valueOne == valueTwo)
        {
            cp = 345012;
        }
        //nothing will change if it is just three of a kind
        return cp;
    }

    int Pair()
    {
        int cp = 0;
        //checks for every single possible pair
        if (valueOne == valueTwo)
        {
            cp = 12;
        }
        else if (valueOne == valueThree)
        {
            cp = 13;
        }
        else if (valueOne == valueFour)
        {
            cp = 14;
        }
        else if (valueOne == valueFive)
        {
            cp = 15;
        }
        else if (valueTwo == valueThree)
        {
            cp = 23;
        }
        else if (valueTwo == valueFour)
        {
            cp = 24;
        }
        else if (valueTwo == valueFive)
        {
            cp = 25;
        }
        else if (valueThree == valueFour)
        {
            cp = 34;
        }
        else if (valueThree == valueFive)
        {
            cp = 35;
        }
        else if (valueFour == valueFive)
        {
            cp = 45;
        }

        if (cp != 0)
        {
            cp = TwoPairCheck(cp);
        }
        return cp;
    }

    int TwoPairCheck(int cp)
    {
        if (cp == 12)
        {
            if (valueThree == valueFour)
            {
                cp = 12034;
            }
            else if (valueThree == valueFive)
            {
                cp = 12035;
            }
            else if (valueFour == valueFive)
            {
                cp = 12045;
            }
        }
        else if (cp == 13)
        {
            if (valueTwo == valueFour)
            {
                cp = 13024;
            }
            else if (valueTwo == valueFive)
            {
                cp = 13025;
            }
            else if (valueFour == valueFive)
            {
                cp = 13045;
            }
        }
        else if (cp == 14)
        {
            if (valueTwo == valueThree)
            {
                cp = 14023;
            }
            else if (valueTwo == valueFive)
            {
                cp = 14025;
            }
            else if (valueThree == valueFive)
            {
                cp = 14035;
            }
        }
        else if (cp == 15)
        {
            if (valueTwo == valueThree)
            {
                cp = 15023;
            }
            else if (valueTwo == valueFour)
            {
                cp = 15024;
            }
            else if (valueThree == valueFour)
            {
                cp = 15034;
            }
        }
        else if (cp == 23)
        {
            if (valueOne == valueFour)
            {
                cp = 23014;
            }
            else if (valueOne == valueFive)
            {
                cp = 23015;
            }
            else if (valueFour == valueFive)
            {
                cp = 23045;
            }
        }
        else if (cp == 24)
        {
            if (valueOne == valueThree)
            {
                cp = 24013;
            }
            else if (valueOne == valueFive)
            {
                cp = 24015;
            }
            else if (valueThree == valueFive)
            {
                cp = 24035;
            }
        }
        else if (cp == 25)
        {
            if (valueOne == valueThree)
            {
                cp = 25013;
            }
            else if (valueOne == valueFour)
            {
                cp = 25014;
            }
            else if (valueThree == valueFour)
            {
                cp = 25034;
            }
        }
        else if (cp == 34)
        {
            if (valueOne == valueTwo)
            {
                cp = 34012;
            }
            else if (valueOne == valueFive)
            {
                cp = 34015;
            }
            else if (valueTwo == valueFive)
            {
                cp = 34025;
            }
        }
        else if (cp == 35)
        {
            if (valueOne == valueTwo)
            {
                cp = 35012;
            }
            else if (valueOne == valueFour)
            {
                cp = 35014;
            }
            else if (valueTwo == valueFour)
            {
                cp = 35024;
            }
        }
        else if (cp == 45)
        {
            if (valueOne == valueTwo)
            {
                cp = 45012;
            }
            else if (valueOne == valueThree)
            {
                cp = 45013;
            }
            else if (valueTwo == valueThree)
            {
                cp = 45023;
            }
        }
        //cp does not change if it is not a double
        return cp;
    }

    int HighCard()
    {
        int cp = 0;
        if (valueOne > valueTwo && valueOne > valueThree && valueOne > valueFour && valueOne > valueFive)
        {
            //valueOne is the highest card
            cp = 1;
        }
        else if (valueTwo > valueThree && valueTwo > valueFour && valueTwo > valueFive)
        {
            //valueTwo is the highest card
            cp = 2;
        }
        else if (valueThree > valueFour && valueThree > valueFive)
        {
            //valueThree is the highest card
            cp = 3;
        }
        else if (valueFour > valueFive)
        {
            //valueFour is the highest card
            cp = 4;
        }
        else
        {
            //valueFive is the highest card
            cp = 5;
        }
        return cp;
    }
}
