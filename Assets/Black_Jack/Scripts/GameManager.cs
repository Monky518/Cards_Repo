using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] cardDeck;

    public GameObject[] bettingButtons;
    public GameObject[] drawingButtons;

    private Vector3[][] playerCardPlacement;
    private Vector3[][] houseCardPlacement;
    private Vector3 cardDeckPlacement;
    private int currentCard = 0;
    private int nextCard = 1;

    private Text playerInfo;
    private GameObject playerObject;

    void Start()
    {
        //set up text
        playerInfo = GameObject.Find("Player Info").GetComponent<Text>();

        //setting up array of array locations
        playerCardPlacement = new Vector3[4][];
        houseCardPlacement = new Vector3[4][];

        //x position even
        int evenOne = 660;
        int evenTwo = 860;
        int evenThree = 1060;
        int evenFour = 1260;
        //x position odd
        int oddOne = 560;
        int oddTwo = 760;
        int oddThree = 960;
        int oddFour = 1160;
        int oddFive = 1360;
        //y position for house and player
        int playerYPosition = 410;
        int houseYPosition = 710;

        //playercards (2-5)
        playerCardPlacement[0] = new[] { new Vector3(evenTwo, playerYPosition, 1), new Vector3(evenThree, playerYPosition, 1) };
        playerCardPlacement[1] = new[] { new Vector3(oddTwo, playerYPosition, 1), new Vector3(oddThree, playerYPosition, 1), new Vector3(oddFour, playerYPosition, 1) };
        playerCardPlacement[2] = new[] { new Vector3(evenOne, playerYPosition, 1), new Vector3(evenTwo, playerYPosition, 1), new Vector3(evenThree, playerYPosition, 1), new Vector3(evenFour, playerYPosition, 1) };
        playerCardPlacement[3] = new[] { new Vector3(oddOne, playerYPosition, 1), new Vector3(oddTwo, playerYPosition, 1), new Vector3(oddThree, playerYPosition, 1), new Vector3(oddFour, playerYPosition, 1), new Vector3(oddFive, playerYPosition, 1) };

        //housecards (2-5)
        houseCardPlacement[0] = new[] { new Vector3(evenTwo, houseYPosition, 1), new Vector3(evenThree, houseYPosition, 1) };
        houseCardPlacement[1] = new[] { new Vector3(oddTwo, houseYPosition, 1), new Vector3(oddThree, houseYPosition, 1), new Vector3(oddFour, houseYPosition, 1) };
        houseCardPlacement[2] = new[] { new Vector3(evenOne, houseYPosition, 1), new Vector3(evenTwo, houseYPosition, 1), new Vector3(evenThree, houseYPosition, 1), new Vector3(evenFour, houseYPosition, 1) };
        houseCardPlacement[3] = new[] { new Vector3(oddOne, houseYPosition, 1), new Vector3(oddTwo, houseYPosition, 1), new Vector3(oddThree, houseYPosition, 1), new Vector3(oddFour, houseYPosition, 1), new Vector3(oddFive, houseYPosition, 1) };

        //setting card deck placement
        cardDeckPlacement = new Vector3(960, 1200, 1);

        ShuffleDeck();
        StartRound();
    }
    
    void ShuffleDeck()
    {
        //used for random range later
        int avaliableCards = 0;
        foreach (GameObject c in cardDeck)
        {
            if (c != null)
            {
                avaliableCards++;
            }
        }

        //actual shuffling time
        for (int card = 0; card < cardDeck.Length; card++)
        {
            if (cardDeck[card] != null)
            {
                //resets placement
                cardDeck[card].transform.position = cardDeckPlacement;

                //actually shuffles the cards
                int randomNumber = Random.Range(0, avaliableCards - 1);

                GameObject cardHolder = cardDeck[card];
                cardDeck[card] = cardDeck[randomNumber];
                cardDeck[randomNumber] = cardHolder;

                //resets all aces to value 11
                if (cardDeck[card].GetComponent<Card>().cardNumber == 1)
                {
                    cardDeck[card].GetComponent<Card>().ChangeAceScore();
                }
            }
            else
            {
                Debug.Log("Hit the bottom of the cardDeck, breaking for loop");
                break;
            }
        }
    }

    void StartRound()
    {
        //give two cards to player and house
        GameObject.Find("Player").GetComponent<Player>().CardUpdate(cardDeck[CardDeckOrder()], 0);
        GameObject.Find("House").GetComponent<House>().CardUpdate(cardDeck[CardDeckOrder()], 0);
        GameObject.Find("Player").GetComponent<Player>().CardUpdate(cardDeck[CardDeckOrder()], 1);
        GameObject.Find("House").GetComponent<House>().CardUpdate(cardDeck[CardDeckOrder()], 1);

        //sets card locations
        GameObject.Find("Player").GetComponent<Player>().playerHand[0].transform.position = playerCardPlacement[0][0];
        GameObject.Find("House").GetComponent<House>().houseHand[0].transform.position = houseCardPlacement[0][0];
        GameObject.Find("Player").GetComponent<Player>().playerHand[1].transform.position = playerCardPlacement[0][1];
        GameObject.Find("House").GetComponent<House>().houseHand[1].transform.position = houseCardPlacement[0][1];
        GameObject.Find("House").GetComponent<House>().houseHand[1].GetComponent<Card>().FlipCard();

        //sets values and starts betting stage
        GameObject.Find("House").GetComponent<House>().HandValueUpdate();
        GameObject.Find("House").GetComponent<House>().AceCheck(0);
        GameObject.Find("House").GetComponent<House>().AceCheck(1);

        GameObject.Find("Player").GetComponent<Player>().HandValueUpdate();
        GameObject.Find("Player").GetComponent<Player>().AceCheck(0);
        GameObject.Find("Player").GetComponent<Player>().AceCheck(1);

        BettingStage();
    }

    void BettingStage()
    {
        foreach (GameObject button in bettingButtons)
        {
            button.SetActive(true);
        }
    }

    public void PlayerDrawing()
    {
        if (GameObject.Find("Player").GetComponent<Player>().bet != 0)
        {
            foreach (GameObject button in bettingButtons)
            {
                button.SetActive(false);
            }

            foreach (GameObject button in drawingButtons)
            {
                button.SetActive(true);
            }
        }
        else if (GameObject.Find("Player").GetComponent<Player>().bet == 0)
        {
            //bet must be over 0
            Debug.Log("Increase bet to at least one");
        }
    }

    public void PlayerDrawCard()
    {
        //give next card (how to know how many cards are currenting there)
        GameObject[] playerCards = GameObject.Find("Player").GetComponent<Player>().playerHand;
        int cardHandLength = 0;
        foreach (GameObject card in playerCards)
        {
            if (card != null)
            {
                cardHandLength++;
            }
        }

        if (cardHandLength != 5)
        {
            //new card!
            GameObject.Find("Player").GetComponent<Player>().CardUpdate(cardDeck[CardDeckOrder()], cardHandLength);

            //updates new card locations (int is one less for array reasons)
            if (cardHandLength == 2)
            {
                GameObject.Find("Player").GetComponent<Player>().playerHand[0].transform.position = playerCardPlacement[1][0];
                GameObject.Find("Player").GetComponent<Player>().playerHand[1].transform.position = playerCardPlacement[1][1];
                GameObject.Find("Player").GetComponent<Player>().playerHand[2].transform.position = playerCardPlacement[1][2];
            }
            else if (cardHandLength == 3)
            {
                GameObject.Find("Player").GetComponent<Player>().playerHand[0].transform.position = playerCardPlacement[2][0];
                GameObject.Find("Player").GetComponent<Player>().playerHand[1].transform.position = playerCardPlacement[2][1];
                GameObject.Find("Player").GetComponent<Player>().playerHand[2].transform.position = playerCardPlacement[2][2];
                GameObject.Find("Player").GetComponent<Player>().playerHand[3].transform.position = playerCardPlacement[2][3];
            }
            else if (cardHandLength == 4)
            {
                GameObject.Find("Player").GetComponent<Player>().playerHand[0].transform.position = playerCardPlacement[3][0];
                GameObject.Find("Player").GetComponent<Player>().playerHand[1].transform.position = playerCardPlacement[3][1];
                GameObject.Find("Player").GetComponent<Player>().playerHand[2].transform.position = playerCardPlacement[3][2];
                GameObject.Find("Player").GetComponent<Player>().playerHand[3].transform.position = playerCardPlacement[3][3];
                GameObject.Find("Player").GetComponent<Player>().playerHand[4].transform.position = playerCardPlacement[3][4];
            }

            //updates new value
            GameObject.Find("Player").GetComponent<Player>().HandValueUpdate();
            GameObject.Find("Player").GetComponent<Player>().AceCheck(cardHandLength);

            if (cardHandLength == 2 || cardHandLength == 3)
            {
                if (GameObject.Find("Player").GetComponent<Player>().playerValue >= 21)
                {
                    HouseDrawCard();
                }
            }
            else if (cardHandLength == 4)
            {
                //moving on
                HouseDrawCard();
            }
        }
    }

    public void HouseDrawCard()
    {
        foreach (GameObject button in drawingButtons)
        {
            button.SetActive(false);
        }

        //loops drawing stage
        GameObject[] houseCards = GameObject.Find("House").GetComponent<House>().houseHand;
        for (int i = 2; i <= 5; i++)
        {
            GameObject house = GameObject.Find("House");
            int cardValue = house.GetComponent<House>().houseValue;

            if (cardValue <= 16)
            {
                //give next card (how to know how many cards are currenting there)
                if (i != 5)
                {
                    //new card!
                    GameObject.Find("House").GetComponent<House>().CardUpdate(cardDeck[CardDeckOrder()], i);

                    //updates new card locations (int is one less because length has not been updated with new card)
                    if (i == 2)
                    {
                        GameObject.Find("House").GetComponent<House>().houseHand[0].transform.position = houseCardPlacement[1][0];
                        GameObject.Find("House").GetComponent<House>().houseHand[1].transform.position = houseCardPlacement[1][1];
                        GameObject.Find("House").GetComponent<House>().houseHand[2].transform.position = houseCardPlacement[1][2];
                        GameObject.Find("House").GetComponent<House>().houseHand[2].GetComponent<Card>().FlipCard();
                    }
                    else if (i == 3)
                    {
                        GameObject.Find("House").GetComponent<House>().houseHand[0].transform.position = houseCardPlacement[2][0];
                        GameObject.Find("House").GetComponent<House>().houseHand[1].transform.position = houseCardPlacement[2][1];
                        GameObject.Find("House").GetComponent<House>().houseHand[2].transform.position = houseCardPlacement[2][2];
                        GameObject.Find("House").GetComponent<House>().houseHand[3].transform.position = houseCardPlacement[2][3];
                        GameObject.Find("House").GetComponent<House>().houseHand[3].GetComponent<Card>().FlipCard();
                    }
                    else if (i == 4)
                    {
                        GameObject.Find("House").GetComponent<House>().houseHand[0].transform.position = houseCardPlacement[3][0];
                        GameObject.Find("House").GetComponent<House>().houseHand[1].transform.position = houseCardPlacement[3][1];
                        GameObject.Find("House").GetComponent<House>().houseHand[2].transform.position = houseCardPlacement[3][2];
                        GameObject.Find("House").GetComponent<House>().houseHand[3].transform.position = houseCardPlacement[3][3];
                        GameObject.Find("House").GetComponent<House>().houseHand[4].transform.position = houseCardPlacement[3][4];
                        GameObject.Find("House").GetComponent<House>().houseHand[4].GetComponent<Card>().FlipCard();
                    }

                    //updates new value
                    GameObject.Find("House").GetComponent<House>().HandValueUpdate();
                    GameObject.Find("House").GetComponent<House>().AceCheck(i);
                }
                else if (i == 5)
                {
                    //moving on
                    Scoring();
                    break;
                }
            }
            else if (cardValue >= 17)
            {
                //stand
                Scoring();
                break;
            }
        }
    }

    public void Scoring()
    {
        //Debug.Log("AAAAASAAAAAAAH -Scoring");
        
        GameObject.Find("House").GetComponent<House>().HandValueUpdate();
        int houseValue = GameObject.Find("House").GetComponent<House>().houseValue;

        GameObject.Find("Player").GetComponent<Player>().HandValueUpdate();
        int playerValue = GameObject.Find("Player").GetComponent<Player>().playerValue;

        //flip cards
        GameObject[] hc = GameObject.Find("House").GetComponent<House>().houseHand;
        for (int i = 1; i < 5; i++)
        {
            if (hc[i] != null)
            {
                hc[i].GetComponent<Card>().FlipCard();
            }
        }

        //for later use
        GameObject[] playerCards = GameObject.Find("Player").GetComponent<Player>().playerHand;
        int cardHandLength = 0;
        foreach (GameObject card in playerCards)
        {
            if (card != null)
            {
                cardHandLength++;
            }
        }

        //all player wins
        if (houseValue > 21 && playerValue <= 21)
        {
            GameObject.Find("Player").GetComponent<Player>().Winner();
            Debug.Log("Player wins");
        }
        else if (playerValue <= 21 && cardHandLength == 5)
        {
            GameObject.Find("Player").GetComponent<Player>().Winner();
            Debug.Log("Player wins");
        }
        else if (houseValue < playerValue && playerValue <= 21)
        {
            GameObject.Find("Player").GetComponent<Player>().Winner();
            Debug.Log("Player wins");
        }
        else
        {
            Debug.Log("Player loses");
        }

        Restart();
    }

    void Restart()
    {
        //put cards back
        for (int i = 0; i < 104; i++)
        {
            //finds empty space
            if (cardDeck[i] == null)
            {
                //grab card from player
                for (int p = 0; p < 5; p++)
                {
                    //finds card
                    if (GameObject.Find("Player").GetComponent<Player>().playerHand[p] != null)
                    {
                        cardDeck[i] = GameObject.Find("Player").GetComponent<Player>().playerHand[p];
                        break;
                    }
                }

                //recheck
                if (cardDeck[i] == null)
                {
                    //grad card from house
                    for (int h = 0; h < 5; h++)
                    {
                        if (GameObject.Find("House").GetComponent<House>().houseHand[h] != null)
                        {
                            cardDeck[i] = GameObject.Find("House").GetComponent<House>().houseHand[h];
                            break;
                        }
                    }
                }

                //final recheck
                if (cardDeck[i] == null)
                {
                    Debug.Log("Putting cards back is broken");
                }
            }

            //resets aces
            if (cardDeck[i].GetComponent<Card>().cardNumber == 1)
            {
                cardDeck[i].GetComponent<Card>().ChangeAceScore();
            }
        }

        //reset bet
        GameObject.Find("Player").GetComponent<Player>().ResetBet();

        //reset player and hosue value
        GameObject.Find("Player").GetComponent<Player>().ResetValue();
        GameObject.Find("House").GetComponent<House>().ResetValue();

        //play again
        StartRound();
    }

    int CardDeckOrder()
    {
        if (cardDeck[nextCard] != null)
        {
            currentCard = nextCard;
            nextCard++;
        }
        else
        {
            ShuffleDeck();
            currentCard = 0;
            nextCard = 1;
        }
        StartCoroutine(PlayingCards(1, currentCard));
        return currentCard;
    }

    IEnumerator PlayingCards(float delay, int placement)
    {
        //yield prevents locking up the game
        yield return new WaitForSeconds(delay);

        //sets playingCards as null in cardDeck
        cardDeck[placement] = null;
    }
}
