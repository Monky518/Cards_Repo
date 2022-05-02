using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject[] givenCards;
    public int buttonNumber;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        givenCards = p.GetComponent<Players>().givenCards;
    }
    
    public void ButtonSelectsCard()
    {
        if (buttonNumber == 0)
        {
            Cards sn = givenCards[0].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 1)
        {
            Cards sn = givenCards[1].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 2)
        {
            Cards sn = givenCards[2].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 3)
        {
            Cards sn = givenCards[3].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 4)
        {
            Cards sn = givenCards[4].GetComponent<Cards>();
            sn.SetCardSelected();
        }
    }
}
