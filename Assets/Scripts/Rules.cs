using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
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

    public int betCoins;
    public GameObject coin;
    private float coinSpawnOffsetX = -2.75f;
    private float coinSpawnOffsetY = 0.5f;

    public GameObject randomCard;
    private GameObject[] allCards;
    private int index;
    private bool testingTakenCard = false;

    void Start()
    {
        //finds all of the cards
        allCards = GameObject.FindGameObjectsWithTag("Card");
        NewRound();
    }

    void Update()
    {
        ///if card is selected
        ///change hold button to draw button
    }

    public GameObject RandomCard()
    {
        //finds a random card
        index = Random.Range(0, allCards.Length);
        if(index != 0)
        {
            randomCard = allCards[index];
            //finds out if that randomCard is already taken
            testingTakenCard = randomCard.GetComponent<Cards>().takenCard;
            if(testingTakenCard)
            {
                //find different random card aka run again
                Debug.Log("already taken");
                return randomCard;
            }
            else
            {
                //sets randomCard as taken before sending back
                GameObject rc = randomCard;
                Cards sn = rc.GetComponent<Cards>();
                sn.SetCardTaken();
                return randomCard;
            }
        }
        else
        {
            return null;
        }
    }

    void NewRound()
    {
        //finds player's coins
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int playerCoins = player.GetComponent<Players>().playerCoins;

        //setting the betting coins
        if (betCoins == 0 && playerCoins != 0)
        {
            Players sn = player.GetComponent<Players>();
            sn.NewPlayerCoins(-1);
            betCoins += 1;
            Instantiate(coin, new Vector2(coinSpawnOffsetX, 5), Quaternion.identity);
        }
        else if(betCoins == 0 && playerCoins == 0)
        {
            ExtraFreshStart();
        }
    }

    public void BetButton()
    {
        //finds player's coins
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int playerCoins = player.GetComponent<Players>().playerCoins;
        if (playerCoins != 0)
        {
            Players sn = player.GetComponent<Players>();
            sn.NewPlayerCoins(-1);
            betCoins += 1;
            Instantiate(coin, new Vector2(coinSpawnOffsetX + (coinSpawnOffsetY * (betCoins -1)), 5), Quaternion.identity);
        }
    }

    public void HoldButton()
    {
        ComputerAightBet();
    }

    public void DrawButton()
    {
        ///when draw button
        ///selected cards change
        ///call computer's betting method
    }

    void ComputerAightBet()
    {
        ///check for scoring

        ///cards not in scoring are drawn again
        ///no cards drawn if all are scored OR lowest scored is drawn

        ///call scoring 
    }

    void ScoringTime()
    {
        ///if full house, set handValue as full house and call high card method
        ///repeat for all
        ///else, call high card method

        ///if player's handValue > computer's handValue
        ///check handValue and multiply betCoins
        ///give betCoins to playerCoins
        ///call method fresh start

        ///if player's handValue < computer's handValue
        ///betCoins = zero
        ///call method fresh start

        ///if player's handValue = computer's handValue
        ///playerCoins += betCoins
        ///call method fresh start
    }

    void HighestCard()
    {
        ///check value of all givenCards
        ///pick highest one
    }

    void FreshStart()
    {
        ///givenCards are null
        ///cardTaken = false
        ///call first cards method
        ///if playerCoins && betCoins = 0, call extra fresh start
    }

    void ExtraFreshStart()
    {
        ///gameover menu with restart button
        ///everything is gone and back to the VERY beginning
    }
}
