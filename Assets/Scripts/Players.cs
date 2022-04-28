using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
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
                givenCards[i].transform.position = new Vector3 (cardLayoutX * i, cardLayoutY , 0);
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
}
