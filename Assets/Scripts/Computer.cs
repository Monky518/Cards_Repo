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
        //no more buttons
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules bs = gm.GetComponent<Rules>();
        bs.ResetButtonPosition();

        //get cardPlacement int to draw new cards and set the handValue
        Scoring s = gm.GetComponent<Scoring>();
        int cardPlacement = s.ScoringTime(givenCards);

        //finalscoringtime()
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