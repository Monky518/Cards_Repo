using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject[] houseHand;
    public int houseValue;

    public void CardUpdate(GameObject card, int placement)
    {
        houseHand[placement] = card;
    }

    public void HandValueUpdate()
    {
        houseValue = 0;

        foreach (GameObject card in houseHand)
        {
            if (card != null)
            {
                houseValue += card.GetComponent<Card>().cardNumber;
            }
        }
    }

    public void AceCheck(int cardPlacement)
    {
        GameObject card = houseHand[cardPlacement];
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
        if (houseValue >= 21)
        {
            //sets back to 1
            if (cn == 11)
            {
                card.GetComponent<Card>().ChangeAceScore();
            }
        }

        HandValueUpdate();
    }

    public void ResetValue()
    {
        houseValue = 0;
    }
}
