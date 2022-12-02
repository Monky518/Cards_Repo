using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] playerHand;
    public int playerValue;

    public int chips = 50;
    public int bet;

    public void IncreaseBet()
    {
        if (chips != 0)
        {
            chips--;
            bet++;
        }
    }

    public void DecreaseBet()
    {
        if (bet != 0)
        {
            chips++;
            bet--;
        }
    }

    public void CardUpdate(GameObject card, int placement)
    {
        playerHand[placement] = card;
    }
    
    public void HandValueUpdate()
    {
        playerValue = 0;

        foreach (GameObject card in playerHand)
        {
            if (card != null)
            {
                playerValue += card.GetComponent<Card>().cardNumber;
            }
        }
    }

    public void AceCheck(int cardPlacement)
    {
        GameObject card = playerHand[cardPlacement];
        int cn = card.GetComponent<Card>().cardNumber;
        if (cn == 1 || cn == 11)
        {
            SetAce(card);
        }
    }

    void SetAce(GameObject card)
    {
        //sets ace to 11
        int cn = card.GetComponent<Card>().cardNumber;
        if (cn == 1)
        {
            card.GetComponent<Card>().ChangeAceScore();
        }

        //checks score
        HandValueUpdate();
        if (playerValue >= 21)
        {
            //sets back to 1
            if (cn == 11)
            {
                card.GetComponent<Card>().ChangeAceScore();
            }
        }

        HandValueUpdate();
    }

    public void Winner()
    {
        chips += bet * 2;
    }

    public void ResetBet()
    {
        bet = 0;
    }

    public void ResetValue()
    {
        playerValue = 0;
    }
}
