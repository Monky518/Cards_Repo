using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rules : MonoBehaviour
{
    public int betCoins;
    private float coinSpawnOffsetX = -4f;
    private float coinSpawnOffsetY = 5.25f;
    private GameObject[] allCards;

    public GameObject coin;

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
    public HandValue compValue;
    public HandValue playerValue;

    void Start()
    {
        allCards = GameObject.FindGameObjectsWithTag("Card");
        NewRound();
    }

    void NewRound()
    {
        //finds player's coins
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int playerCoins = player.GetComponent<Player_LP>().playerCoins;

        //setting the betting coins
        if (betCoins == 0 && playerCoins != 0)
        {
            //minimum one betting coin
            Player_LP sn = player.GetComponent<Player_LP>();
            sn.NewPlayerCoins(-1);
            betCoins += 1;

            //visual coin and button
            Instantiate(coin, new Vector2(coinSpawnOffsetX, coinSpawnOffsetY), Quaternion.identity);
        }
        else if (betCoins == 0 && playerCoins == 0)
        {
            ExtraFreshStart();
        }
    }

    public GameObject RandomCard()
    {
        //finds a random card
        int index = Random.Range(0, allCards.Length);
        GameObject randomCard = allCards[index];
        GameObject test = TestingRandomCard(randomCard);
        return test;
    }

    public GameObject TestingRandomCard(GameObject t)
    {
        bool testingCard = t.GetComponent<Cards>().takenCard;
        if (testingCard)
        {
            //loop time
            GameObject rerun = RandomCard();
            return rerun;
        }
        else
        {
            //sets randomCard as taken before sending back
            GameObject rc = t;
            Cards sn = rc.GetComponent<Cards>();
            sn.SetCardTaken();
            return t;
        }
    }

    public void SetBetCoins(int bc)
    {
        betCoins += bc;
    }

    public void FinalScoringTime()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Scoring boo = gm.GetComponent<Scoring>();

        //computer
        GameObject comp = GameObject.FindGameObjectWithTag("Computer");
        GameObject[] compHand = comp.GetComponent<Computer>().givenCards;
        int compCp = boo.ScoringTime(compHand);

        //player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] playerHand = player.GetComponent<Player_LP>().givenCards;
        int playerCp = boo.ScoringTime(playerHand);

        //finds computer hand value
        if (compCp > 100000)
        {
            //full house
            compValue = HandValue.FullHouse;
        }
        else if (compCp > 10000)
        {
            //two pair
            compValue = HandValue.TwoPairs;
        }
        else if (compCp > 1000)
        {
            //four of a kind
            compValue = HandValue.FourOfAKind;
        }
        else if (compCp > 100)
        {
            //three of a kind
            compValue = HandValue.ThreeOfAKind;
        }
        else if (compCp > 10)
        {
            //pair
            compValue = HandValue.Pair;
        }
        else if (compCp >= 1)
        {
            //high card
            compValue = HandValue.HighCard;
        }
        else
        {
            Debug.Log("Something is very wrong computer edition: " + compCp);
        }
        
        //finds player hand value
        if (playerCp > 100000)
        {
            //full house
            playerValue = HandValue.FullHouse;
        }
        else if (playerCp > 10000)
        {
            //two pair
            playerValue = HandValue.TwoPairs;
        }
        else if (playerCp > 1000)
        {
            //four of a kind
            playerValue = HandValue.FourOfAKind;
        }
        else if (playerCp > 100)
        {
            //three of a kind
            playerValue = HandValue.ThreeOfAKind;
        }
        else if (playerCp > 10)
        {
            //pair
            playerValue = HandValue.Pair;
        }
        else if (playerCp >= 1)
        {
            //high card
            playerValue = HandValue.HighCard;
        }
        else
        {
            Debug.Log("Something is very wrong player edition: " + playerCp);
        }

        //compares cards for the winner
        bool playerWins = false;
        bool compWins = false;
        if (playerValue == compValue)
        {
            //tie has occured because I do not have anything set up for high card
            playerWins = true;
            compWins = true;
        }
        else if (playerValue == HandValue.FourOfAKind)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.FourOfAKind)
        {
            //computer wins
            compWins = true;
        }
        else if (playerValue == HandValue.FullHouse)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.FullHouse)
        {
            //computer wins
            compWins = true;
        }
        else if (playerValue == HandValue.ThreeOfAKind)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.ThreeOfAKind)
        {
            //computer wins
            compWins = true;
        }
        else if (playerValue == HandValue.TwoPairs)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.TwoPairs)
        {
            //computer wins
            compWins = true;
        }
        else if (playerValue == HandValue.Pair)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.Pair)
        {
            //computer wins
            compWins = true;
        }
        else if (playerValue == HandValue.HighCard)
        {
            //player wins
            playerWins = true;
        }
        else if (compValue == HandValue.HighCard)
        {
            //computer wins
            compWins = true;
        }

        //finds player before sending new coins
        Player_LP gottem = player.GetComponent<Player_LP>();
        TextMeshProUGUI tempText = GameObject.Find("Temp Text").GetComponent<TextMeshProUGUI>();
        if (compWins && playerWins)
        {
            //add betCoins to playerCoins
            gottem.PlayerCoins(betCoins);

            //temp text
            tempText.text = ("TIE");
        }
        else if (compWins)
        {
            //set betCoins to zero
            betCoins = 0;

            //temp text
            tempText.text = ("COMPUTER WINS");
        }
        else if (playerWins)
        {
            //multiply depending on win
            if (playerValue == HandValue.FourOfAKind)
            {
                //eight
                betCoins *= 8;
                gottem.PlayerCoins(betCoins);
            }
            else if (playerValue == HandValue.FullHouse)
            {
                //six
                betCoins *= 6;
                gottem.PlayerCoins(betCoins);
            }
            else if (playerValue == HandValue.ThreeOfAKind)
            {
                //four
                betCoins *= 4;
                gottem.PlayerCoins(betCoins);
            }
            else if (playerValue == HandValue.TwoPairs)
            {
                //three
                betCoins *= 3;
                gottem.PlayerCoins(betCoins);
            }
            else if (playerValue == HandValue.Pair)
            {
                //two
                betCoins *= 2;
                gottem.PlayerCoins(betCoins);
            }
            //temp text
            tempText.text = ("PLAYER WINS");
        }
        FreshStart();
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
