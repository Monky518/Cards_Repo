using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject[] givenCards;

    public int cardLayoutX;
    public int cardLayoutY;
    public GameObject cardBack;

    public int playerCoins;
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
    public int highCardNumber;

    private TextMeshProUGUI playerCoinText;

    void Start()
    {
        FirstCards();
        playerCoinText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //I cannot change script order for only this dumb thing
        if (playerCoinText != null)
        {
            playerCoinText.text = playerCoins.ToString();
        }
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
                givenCards[i].transform.position = new Vector3(cardLayoutX * i, cardLayoutY, 0);
            }
        }
    }

    public void NewPlayerCoins(int c)
    {
        playerCoins += c;
    }

    public void ScoringTime()
    {
        //THIS IS REALLY GROSS, BUT IT IS THE BEST I CAN DO RIGHT NOW
        //cardValue found
        int valueOne = givenCards[0].GetComponent<Cards>().cardNumber;
        int valueTwo = givenCards[1].GetComponent<Cards>().cardNumber;
        int valueThree = givenCards[2].GetComponent<Cards>().cardNumber;
        int valueFour = givenCards[3].GetComponent<Cards>().cardNumber;
        int valueFive = givenCards[4].GetComponent<Cards>().cardNumber;
        Debug.Log("P valueOne: " + valueOne);
        Debug.Log("P valueTwo: " + valueTwo);
        Debug.Log("P valueThree: " + valueThree);
        Debug.Log("P valueFour: " + valueFour);
        Debug.Log("P valueFive: " + valueFive);

        //jokerCard found
        for (int i = 0; i < givenCards.Length; i++)
        {
            Cards sn = givenCards[i].GetComponent<Cards>();
            bool Joker = sn.JokerCardFinder();
        }
    }

    public void PlayerScoringTime()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Scoring s = gm.GetComponent<Scoring>();
        int playerHand = s.ScoringTime(givenCards);
    }
}