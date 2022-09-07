using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int buttonNumber;

    private float coinSpawnOffsetX = -4f;
    private float coinSpawnInterval = 0.5f;
    private float coinSpawnOffsetY = 5.25f;

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
        //next phase
        GameObject comp = GameObject.FindGameObjectWithTag("Computer");
        Computer boo = comp.GetComponent<Computer>();
        boo.ComputerAightBet();
    }

    public void HoldButton()
    {
        //next phase
        GameObject comp = GameObject.FindGameObjectWithTag("Computer");
        Computer boo = comp.GetComponent<Computer>();
        boo.ComputerAightBet();
    }
}
