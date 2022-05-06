using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public bool isComputer;
    public GameObject cardBack;

    public GameObject[] givenCards;
    private GameObject testingCard;

    public int cardLayoutX;
    public int cardLayoutY;

    public int playerCoins;

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
            sn.RandomCard();
            testingCard = gm.GetComponent<Rules>().randomCard;

            //sets the random card as part of the hand
            if (testingCard != null)
            {
                givenCards[i] = testingCard;
                testingCard = null;

                //sets the card position
                if (!isComputer)
                {
                    givenCards[i].transform.position = new Vector3(cardLayoutX * i, cardLayoutY, 0);
                }
                else
                {
                    Instantiate(cardBack, new Vector2(cardLayoutX * i, cardLayoutY), Quaternion.identity);
                }
            }
        }
    }

    public void NewPlayerCoins(int c)
    {
        playerCoins += c;
    }

    public void DrawCard(GameObject c)
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules sn = gm.GetComponent<Rules>();

        //fix this after selecting a card and triggering the button
        //givenCards[c] = sn.RandomCard();
    }

    public void DrawButton()
    {
        //finds selected cards
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules sn = gm.GetComponent<Rules>();

        for (int i = 0; i < givenCards.Length; i++)
        {
            //checks for see if any cards are selected
            bool b = givenCards[i].GetComponent<Cards>().selectedCard;
            if (b)
            {
                givenCards[i].transform.position = new Vector3(13.75f, 5, 0);

                givenCards[i] = sn.RandomCard();
                givenCards[i].transform.position = new Vector3(cardLayoutX * i, cardLayoutY, 0);
            }
        }
        //old cards no longer taken (if it even matters)
        sn.ComputerAightBet();
    }

    public void HoldButton()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules sn = gm.GetComponent<Rules>();
        sn.ComputerAightBet();
    }

    public void ScoringTime()
    {
        //all cards same suit
        //set as royal flush
        //how many have the same number
        //set as thing
        //high card
    }
}