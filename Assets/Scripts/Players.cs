using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public GameObject[] givenCards;
    public GameObject testingCard;

    public Vector3 cardLayout;
    
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
                givenCards[i].transform.position += (Vector3)cardLayout * i;
            }
        }
    }
}
