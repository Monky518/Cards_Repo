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
        Triple,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
    public HandValue handValue;

    public int playerCoins;
    public int betCoins;

    public GameObject randomCard;
    public GameObject[] allCards;
    private int index;

    void Start()
    {
        //finds all of the cards
        allCards = GameObject.FindGameObjectsWithTag("Card");
    }

    public GameObject RandomCard()
    {
        //finds a random card
        Debug.Log(allCards.Length);
        index = Random.Range(0, allCards.Length);
        if(index != 0)
        {
            randomCard = allCards[index];
            return randomCard;
        }
        else
        {
            return null;
        }
    }

    void NewRound()
    {
        if (betCoins == 0 && playerCoins != 0)
        {
            playerCoins -= 1;
            betCoins += 1;
            AightBet();
        }
        else if(betCoins > 0)
        {
            AightBet();
        }
        else if(betCoins == 0 && playerCoins == 0)
        {
            ExtraFreshStart();
        }
    }

    void AightBet()
    {
        ///when bet button
        ///add 1 coin to pot

        ///when hold button
        ///call computer's betting method

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
