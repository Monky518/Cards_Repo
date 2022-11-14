using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] cardDeck;
    public float cardSpeed;

    public GameObject[] playerHand;
    public int playerValue;

    public GameObject[] houseHand;
    public int houseValue;

    public int playerChips = 50;
    public int playerBet;

    private Vector3[][] playerCardPlacement;
    private Vector3[][] houseCardPlacement;
    private Vector3 cardDeckPlacement;
    private int currentCard;
    private int nextCard;

    void Start()
    {
        //setting up array of array locations
        playerCardPlacement = new Vector3[4][];
        houseCardPlacement = new Vector3[4][];

        //playercards (2-5)
        playerCardPlacement[0] = new[] { new Vector3(870f, 410f, 1f), new Vector3(1070f, 410f, 1f) };
        playerCardPlacement[1] = new[] { new Vector3(770f, 410f, 1f), new Vector3(970f, 410f, 1f), new Vector3(1170f, 410f, 1f) };
        playerCardPlacement[2] = new[] { new Vector3(670f, 410f, 1f), new Vector3(870f, 410f, 1f), new Vector3(1070f, 410f, 1f), new Vector3(1270f, 410f, 1f) };
        playerCardPlacement[3] = new[] { new Vector3(570f, 410f, 1f), new Vector3(770f, 410f, 1f), new Vector3(970f, 410f, 1f), new Vector3(1170f, 410f, 1f), new Vector3(1370f, 410f, 1f) };

        //housecards (2-5)
        houseCardPlacement[0] = new[] { new Vector3(870f, 710f, 1f), new Vector3(1070f, 710f, 1f) };
        houseCardPlacement[1] = new[] { new Vector3(770f, 710f, 1f), new Vector3(970f, 710f, 1f), new Vector3(1170f, 710f, 1f) };
        houseCardPlacement[2] = new[] { new Vector3(670f, 710f, 1f), new Vector3(870f, 710f, 1f), new Vector3(1070f, 710f, 1f), new Vector3(1270f, 710f, 1f) };
        houseCardPlacement[3] = new[] { new Vector3(570f, 710f, 1f), new Vector3(770f, 710f, 1f), new Vector3(970f, 710f, 1f), new Vector3(1170f, 710f, 1f), new Vector3(1370f, 710f, 1f) };

        //setting card deck placement
        cardDeckPlacement = new Vector3(960f, 1200f, 1f);

        ShuffleDeck();
        StartRound();
    }

    void Update()
    {
        
    }
    
    void ShuffleDeck()
    {
        for (int card = 0; card < cardDeck.Length; card++)
        {
            //resets placement
            cardDeck[card].transform.position = cardDeckPlacement;

            //actually shuffles the cards
            int randomNumber = Random.Range(0, cardDeck.Length - 1);
            
            GameObject cardHolder = cardDeck[card];
            cardDeck[card] = cardDeck[randomNumber];
            cardDeck[randomNumber] = cardHolder;

            //resets all aces to value 11
            if (cardDeck[card].GetComponent<Card>().cardNumber == 1)
            {
                cardDeck[card].GetComponent<Card>().ChangeAceScore();
            }
        }
    }
    
    void StartRound()
    {
        //give two cards to player and house
        playerHand[0] = cardDeck[CardDeckOrder()];
        houseHand[0] = cardDeck[CardDeckOrder()];
        playerHand[1] = cardDeck[CardDeckOrder()];
        houseHand[1] = cardDeck[CardDeckOrder()];

        playerHand[0].transform.position = playerCardPlacement[0][0] * Time.deltaTime * cardSpeed;
        houseHand[0].transform.position = houseCardPlacement[0][0] * Time.deltaTime * cardSpeed;
        playerHand[1].transform.position = playerCardPlacement[0][1] * Time.deltaTime * cardSpeed;
        //flips to cardBack before showing on screen
        houseHand[1].GetComponent<Card>().FlipCard();
        houseHand[1].transform.position = playerCardPlacement[0][1] * Time.deltaTime * cardSpeed;

        //sets values and starts betting stage
        HandValueUpdate();
        AceCheck(houseHand);
        AceCheck(playerHand);
        BettingStage();
    }

    void BettingStage()
    {
        
    }

    public void PlayerDrawing()
    {
        
    }

    public void HouseDrawing()
    {

    }

    public void Restart()
    {
        //playerHand and houseHand are empty aka return cards
        //playerValue, houseValue, and playerBet are zero

        //reshuffle cards
    }

    void HandValueUpdate()
    {
        foreach (GameObject card in playerHand)
        {
            if (card != null)
            {
                playerValue += card.GetComponent<Card>().cardNumber;
            }
        }

        foreach (GameObject card in houseHand)
        {
            if (card != null)
            {
                houseValue += card.GetComponent<Card>().cardNumber;
            }
        }
    }

    void AceCheck(GameObject[] hand)
    {
        foreach (GameObject card in hand)
        {
            if (card != null)
            {
                int cn = card.GetComponent<Card>().cardNumber;
                if (cn == 1 || cn == 11)
                {
                    SetAce(card);
                }
            }
        }
    }

    void SetAce(GameObject card)
    {
        //sets all aces to 11
        int cn = card.GetComponent<Card>().cardNumber;
        if (cn == 1)
        {
            card.GetComponent<Card>().ChangeAceScore();
        }

        //FAKE CN, change later
        if (cn == 1)
        {
            ///stop everything
            ///run the buttons
            ///return to normal

            //temp copy of house design
            if (playerValue >= 21)
            {
                //set ace to 1
                card.GetComponent<Card>().ChangeAceScore();
            }
        }
        else
        {
            if (houseValue >= 21)
            {
                //set ace to 1
                card.GetComponent<Card>().ChangeAceScore();
            }
        }
    }

    int CardDeckOrder()
    {
        if (currentCard == 51 && nextCard == 52)
        {
            ShuffleDeck();
            currentCard = 0;
            nextCard = 1;
        }
        else
        {
            currentCard = nextCard;
            nextCard++;
        }
        return currentCard;
    }
}
