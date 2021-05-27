﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameLoop : MonoBehaviour
{
    public Player player1;
    public Player player2;
    [HideInInspector] public Player turnPlayer;
    private Turn turnState;
    private UIManager ui;

    private enum Turn
    {
        DRAW,
        PLAY_CARD,
        ATTACK,
        ENDTURN,
    }
    void Start()
    {
        ui = GetComponent<UIManager>();
        VuforiaUnity.SetHint(VuforiaUnity.VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, Player.sizeFieldCards * 2);
        if (Random.Range(1, 2) == 1)
            turnPlayer = player1;
        else
            turnPlayer = player2;
        ChangeDrawState();
    }

    // Update is called once per frame
    void Update()
    {
        TurnLogic();
    }

    private void ChangeDrawState()
    {
        if (!turnPlayer.AllDeckDrawed())
        {
            turnState = Turn.DRAW;
            ui.UiDraw();
        }
        else
            ChangeAttackState();
    }
    public void ChangeAttackState()
    {
        turnState = Turn.ATTACK;
        ui.UiAttack();
    }
    public void ChangePlayCardState()
    {
        turnState = Turn.PLAY_CARD;
        ui.UiPlay();
    }
    public void ChangeEndTurnState()
    {
        turnState = Turn.ENDTURN;
        ui.DisableAllUi();
    }
    public bool DetectedNewCard(Card card)
    {
        if (turnState != Turn.DRAW)
            return false;

        if (turnPlayer.AddCard(card))
        {
            ChangeAttackState();
            card.RegisterCard();
            Debug.Log("Succesful draw card");
            return true;
        }
        else
        {
            Debug.LogWarning("invalid card to draw");
            return false;
        }
    }

    public void DetectedRegisteredCard(Card card)
    {
        if (turnState != Turn.PLAY_CARD)
            return;

        if (turnPlayer.PlayCard(card))
        {
            Debug.Log("Succesful played card");
            ChangeEndTurnState();
        }
        else
            Debug.LogWarning("Cant play this card: Card not in hand");
    }
    void SwapTurnPlayer()
    {
        if (turnPlayer == player1)
            turnPlayer = player2;
        else if (turnPlayer == player2)
            turnPlayer = player1;
    }
    void EndTurn()
    {
        //check win lose players
        //player.CheckLose();
        SwapTurnPlayer();
    }

    void TurnLogic()
    {
        switch(turnState)
        {
            case Turn.DRAW:
                break;

            case Turn.PLAY_CARD:
                break;

            case Turn.ATTACK:
                //ui.UiAttack();
                //turnState = Turn.ENDTURN;
                break;

            case Turn.ENDTURN:
                EndTurn();
                ChangeDrawState();
                Debug.Log("turn has ended");
                break;
        }
    }
}
