using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AceButtons : MonoBehaviour
{
    private GameObject aceCard;
    private bool betting, drawing;
    
    public void FutureCard(GameObject card, bool bet, bool draw)
    {
        aceCard = card;
        betting = bet;
        drawing = draw;
    }

    public void SetAce()
    {
        GameObject.Find("Player").GetComponent<Player>().HandValueUpdate();
        
        foreach (GameObject ab in GameObject.Find("GameManager").GetComponent<GameManager>().aceButtons)
        {
            ab.SetActive(false);
            Debug.Log(ab);
        }

        if (drawing)
        {
            foreach (GameObject db in GameObject.Find("GameManager").GetComponent<GameManager>().drawingButtons)
            {
                db.SetActive(true);
            }
        }
        else if (betting)
        {
            foreach (GameObject bb in GameObject.Find("GameManager").GetComponent<GameManager>().bettingButtons)
            {
                bb.SetActive(true);
            }
        }
    }

    public void ChangeAce()
    {
        //change number and updates score
        aceCard.GetComponent<Card>().ChangeAceScore();
        GameObject.Find("Player").GetComponent<Player>().HandValueUpdate();
    }
}
