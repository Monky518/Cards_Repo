using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int buttonNumber;

    private float coinSpawnOffsetX = -4f;
    private float coinSpawnInterval = 0.5f;
    private float coinSpawnOffsetY = 5.25f;

    public GameObject hold;
    public GameObject draw;

    public void ButtonSelectsCard()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        GameObject[] gc = p.GetComponent<Player>().givenCards;

        if (buttonNumber == 0)
        {
            Cards sn = gc[0].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 1)
        {
            Cards sn = gc[1].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 2)
        {
            Cards sn = gc[2].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 3)
        {
            Cards sn = gc[3].GetComponent<Cards>();
            sn.SetCardSelected();
        }
        else if (buttonNumber == 4)
        {
            Cards sn = gc[4].GetComponent<Cards>();
            sn.SetCardSelected();
        }
    }

    public void BetButton()
    {
        //finds player's coins
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int playerCoins = player.GetComponent<Player>().playerCoins;
        if (playerCoins != 0)
        {
            //one player coin is gone
            Player sn = player.GetComponent<Player>();
            sn.NewPlayerCoins(-1);

            //one bet coin is added
            GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
            Rules boo = gm.GetComponent<Rules>();
            int bc = 1;
            boo.SetBetCoins(bc);

            //visual coin exists
            int ace = gm.GetComponent<Rules>().betCoins;
            GameObject c = GameObject.FindGameObjectWithTag("Coin");
            Instantiate(c, new Vector2(coinSpawnOffsetX + (coinSpawnInterval * (ace - 1)), coinSpawnOffsetY), Quaternion.identity);
        }
    }

    public void DrawButton()
    {
        //finds selected cards
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Rules sn = gm.GetComponent<Rules>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] gc = player.GetComponent<Player>().givenCards;

        for (int i = 0; i < gc.Length; i++)
        {
            //checks for see if any cards are selected
            bool b = gc[i].GetComponent<Cards>().selectedCard;
            if (b)
            {
                gc[i].transform.position = new Vector3(13.75f, 5, 0);

                gc[i] = sn.RandomCard();

                int x = player.GetComponent<Player>().cardLayoutX;
                int y = player.GetComponent<Player>().cardLayoutY;
                gc[i].transform.position = new Vector3(x * i, y, 0);
            }
        }

        GameObject comp = GameObject.FindGameObjectWithTag("Computer");
        Computer boo = comp.GetComponent<Computer>();
        boo.ComputerAightBet();
        //no more buttons
        Vector3 offScreen = gm.GetComponent<Rules>().offScreen;
        hold.transform.position = offScreen;
        draw.transform.position = offScreen;
    }

    public void HoldButton()
    {
        GameObject comp = GameObject.FindGameObjectWithTag("Computer");
        Computer boo = comp.GetComponent<Computer>();
        boo.ComputerAightBet();
        //no more buttons
        GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
        Vector3 offScreen = gm.GetComponent<Rules>().offScreen;
        hold.transform.position = offScreen;
        draw.transform.position = offScreen;
    }
}
