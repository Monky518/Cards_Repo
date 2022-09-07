using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] playerHand;
    public GameObject[] houseHand;
    public GameObject[,] cardDeck = new GameObject[2000, 0];
    
    void Start()
    {
        CardDeck();
        Debug.Log(cardDeck);
    }

    void Update()
    {

    }
    
    void CardDeck()
    {
        ///shuffle the cards when necessary
        //for now, everything goes it a box
        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject o in objects)
        {
            Vector2 pos = o.transform.position;
            if (o.tag == "Card")
            {
                cardDeck[(int)pos.x, (int)pos.y] = o;
            }
        }
    }
    
    void Round()
    {
        ///give two cards to player and house
        ///begin betting stage
        ///player draw
        ///house draws
        ///results
        ///reset
    }
}
