using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private const int deckSize = 1;
    private Card[] player1Cards;
    private Card[] player2Cards;
    private int currentPlayer;
    private Turn turn;
    private Card lastRegisteredCard;
    private bool registeredCard = false;
    private int player1NumCards = 0;
    private int player2NumCards = 0;

    private enum Turn
    {
        DRAW,
        ATTACK,
        ENDTURN,
    }
    void Start()
    {
        Debug.Log("game loop is working");
        player1Cards = new Card[deckSize];
        player2Cards = new Card[deckSize];

        currentPlayer = Random.Range(1, 2);
        turn = Turn.DRAW;
    }

    // Update is called once per frame
    void Update()
    {

        TurnLogic();
    }

    public void TakeCard(Card card)
    {
        if(card.id != -1)
        {
            card.enabled = false;
            return;
        }

        if(registeredCard)
        {
            return;
        }

        if (currentPlayer == 1)
        {
            for (int i = 0; i < deckSize; ++i)
            {
                if(player1Cards[i].id == card.id)
                {
                    lastRegisteredCard = card;
                    registeredCard = true;
                    break;
                }
            }
        }

        else if (currentPlayer == 2)
        {
            for (int i = 0; i < deckSize; ++i)
            {
                if (player2Cards[i].id == card.id)
                {
                    lastRegisteredCard = card;
                    registeredCard = true;
                    break;
                }
            }
        }
    }

    void EndTurn()
    {
        if (currentPlayer == 1)
            currentPlayer = 2;
        else if (currentPlayer == 2)
            currentPlayer = 1;
    }

    void TurnLogic()
    {
        switch(turn)
        {
            case Turn.DRAW:
                if(registeredCard)
                {
                    if (currentPlayer == 1)
                    {
                        Debug.Log("player1 drawing card");
                        player1Cards[player1NumCards] = lastRegisteredCard;
                        ++player1NumCards;
                    }

                    else if (currentPlayer == 2)
                    {
                        Debug.Log("player2 drawing card");
                        player2Cards[player2NumCards] = lastRegisteredCard;
                        ++player2NumCards;
                    }

                    registeredCard = false;
                    turn = Turn.ATTACK;
                }
                break;

            case Turn.ATTACK:
                turn = Turn.ENDTURN;
                break;

            case Turn.ENDTURN:
                EndTurn();
                Debug.Log("turn has ended");
                break;

        }
    }


}
