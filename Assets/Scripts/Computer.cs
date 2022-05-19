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

    private GameObject[] unusedCards;

    void Start()
    {
        FirstCards();
    }

    void FirstCards()
    {
        for (int i = 0; i < 5; i++)
        {
            //calls random card method
            GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
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
        //get cardPlacement int to draw new cards and set the handValue
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Scoring s = gm.GetComponent<Scoring>();
        int cardPlacement = s.ScoringTime(givenCards);

        if (cardPlacement > 100000)
        {
            //full house
            Debug.Log("Nice Job!");
        }
        else if (cardPlacement > 10000)
        {
            //two pair
            if (cardPlacement == 23045)
            {
                //set card 1 as selected
                Cards c = givenCards[0].GetComponent<Cards>();
            }
            else if (cardPlacement == 15034 || cardPlacement == 14035 || cardPlacement == 13045)
            {
                //set card 2 as selected
                Cards c = givenCards[1].GetComponent<Cards>();
            }
            else if (cardPlacement == 15024 || cardPlacement == 14025 || cardPlacement == 12045)
            {
                //set card 3 as selected
                Cards c = givenCards[2].GetComponent<Cards>();
            }
            else if (cardPlacement == 15023 || cardPlacement == 13025 || cardPlacement == 12035)
            {
                //set card 4 as selected
                Cards c = givenCards[3].GetComponent<Cards>();
            }
            else if (cardPlacement == 14023 || cardPlacement == 13024 || cardPlacement == 12034)
            {
                //set card 5 as selected
                Cards c = givenCards[4].GetComponent<Cards>();
            }
            else
            {
                Debug.Log("Mistake");
            }
        }
        else if (cardPlacement > 1000)
        {
            //four of a kind
            if (cardPlacement == 1234)
            {
                //set card 5 as selected
                Cards c = givenCards[4].GetComponent<Cards>();
                c.SetCardSelected();
            }
            else if (cardPlacement == 1235)
            {
                //set card 4 as selected
                Cards c = givenCards[3].GetComponent<Cards>();
                c.SetCardSelected();
            }
            else if (cardPlacement == 1245)
            {
                //set card 3 as selected
                Cards c = givenCards[2].GetComponent<Cards>();
                c.SetCardSelected();
            }
            else if (cardPlacement == 1345)
            {
                //set card 2 as selected
                Cards c = givenCards[1].GetComponent<Cards>();
                c.SetCardSelected();
            }
            else if (cardPlacement == 2345)
            {
                //set card 1 as selected
                Cards c = givenCards[0].GetComponent<Cards>();
                c.SetCardSelected();
            }
            else
            {
                Debug.Log("Mistake");
            }
        }
        else if (cardPlacement > 100)
        {
            //three of a kind
            if (cardPlacement == 123)
            {
                //set card 4 5 as selected
                Cards c1 = givenCards[3].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 124)
            {
                //set card 3 5 as selected
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 125)
            {
                //set card 3 4 as selected
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 134)
            {
                //set card 2 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 135)
            {
                //set card 2 4 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 145)
            {
                //set card 2 3 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 234)
            {
                //set card 1 5 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 245)
            {
                //set card 1 3 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else if (cardPlacement == 345)
            {
                //set card 1 2 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[1].GetComponent<Cards>();
                c1.SetCardSelected();
                c2.SetCardSelected();
            }
            else
            {
                Debug.Log("Mistake");
            }
        }
        else if (cardPlacement > 10)
        {
            //pair
            if (cardPlacement == 12)
            {
                //set card 3 4 5 as selected
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 13)
            {
                //set card 2 4 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 14)
            {
                //set card 2 3 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 15)
            {
                //set card 2 3 4 as selected
                Cards c1 = givenCards[2].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                Cards c3 = givenCards[1].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 23)
            {
                //set card 1 4 5 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 24)
            {
                //set card 1 3 5 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 25)
            {
                //set card 1 3 4 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                Cards c3 = givenCards[3].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 34)
            {
                //set card 1 2 5 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[1].GetComponent<Cards>();
                Cards c3 = givenCards[4].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 35)
            {
                //set card 1 2 4 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[1].GetComponent<Cards>();
                Cards c3 = givenCards[3].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else if (cardPlacement == 45)
            {
                //set card 1 2 3 as selected
                Cards c1 = givenCards[0].GetComponent<Cards>();
                Cards c2 = givenCards[1].GetComponent<Cards>();
                Cards c3 = givenCards[2].GetComponent<Cards>();
                //new card!
                c1.SetCardSelected();
                c2.SetCardSelected();
                c3.SetCardSelected();
            }
            else
            {
                Debug.Log("Mistake");
            }
        }
        else if (cardPlacement > 1)
        {
            //high card
            if (cardPlacement == 1)
            {
                //set card 2 3 4 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                Cards c3 = givenCards[3].GetComponent<Cards>();
                Cards c4 = givenCards[4].GetComponent<Cards>();
            }
            else if (cardPlacement == 2)
            {
                //set card 1 2 3 4 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[2].GetComponent<Cards>();
                Cards c3 = givenCards[3].GetComponent<Cards>();
                Cards c4 = givenCards[0].GetComponent<Cards>();
            }
            else if (cardPlacement == 3)
            {
                //set card 1 2 4 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                Cards c3 = givenCards[3].GetComponent<Cards>();
                Cards c4 = givenCards[0].GetComponent<Cards>();
            }
            else if (cardPlacement == 4)
            {
                //set card 1 2 3 5 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[4].GetComponent<Cards>();
                Cards c3 = givenCards[2].GetComponent<Cards>();
                Cards c4 = givenCards[0].GetComponent<Cards>();
            }
            else if (cardPlacement == 5)
            {
                //set card 1 2 3 4 as selected
                Cards c1 = givenCards[1].GetComponent<Cards>();
                Cards c2 = givenCards[3].GetComponent<Cards>();
                Cards c3 = givenCards[2].GetComponent<Cards>();
                Cards c4 = givenCards[0].GetComponent<Cards>();
            }
            else
            {
                Debug.Log("Mistake");
            }
        }
        else
        {
            Debug.Log("Something is ever wrong");
        }
        //new cards!
        RedrawCards();
        //end turn
        Rules r = gm.GetComponent<Rules>();
        r.FinalScoringTime();
    }

    public void RedrawCards()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
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
}