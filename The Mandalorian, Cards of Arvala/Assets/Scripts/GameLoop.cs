using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameLoop : MonoBehaviour
{
    public Player player1;
    public Player player2;
    [HideInInspector] public Player turnPlayer;
    [HideInInspector] public Player opponent;
    private Turn turnState;
    private UIManager ui;
    private SelectManager selectManager;

    private enum Turn
    {
        DRAW,
        ACTION_SELECTION,
        PLAY_CARD,
        ATTACK,
        END_TURN,
        END_GAME
    }
    void Start()
    {
        ui = GetComponent<UIManager>();
        selectManager = GetComponent<SelectManager>();
        VuforiaUnity.SetHint(VuforiaUnity.VuforiaHint.HINT_MAX_SIMULTANEOUS_IMAGE_TARGETS, Player.sizeFieldCards * 2);
        if (Random.Range(1, 2) == 1)
        {
            turnPlayer = player1;
            opponent = player2;
        }
        else
        {
            turnPlayer = player2;
            opponent = player1;
        }
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
            ChangeActionSelectionState();
    }
    public void ChangeActionSelectionState()
    {
        turnState = Turn.ACTION_SELECTION;
        ui.UiActionSelection();
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
        turnState = Turn.END_TURN;
        ui.DisableAllUi();
    }
    public bool DetectedNewCard(Card card)
    {
        if (turnState != Turn.DRAW)
            return false;

        if (turnPlayer.AddCard(card))
        {
            ChangeActionSelectionState();
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
        Player temp = turnPlayer;
        turnPlayer = opponent;
        opponent = temp;
    }
    void EndTurn()
    {
        //check win lose players
        //player.CheckLose();
        selectManager.ResetSelections();
        SwapTurnPlayer();
    }

    private bool EndGame()
    {
        if(opponent.EmptyHand() && opponent.EmptyField() && opponent.AllDeckDrawed())
        {
            return true;
        }
        return false;
    }

    void TurnLogic()
    {
        switch(turnState)
        {
            case Turn.DRAW:
                break;

            case Turn.ACTION_SELECTION:
                break;

            case Turn.PLAY_CARD:
                break;

            case Turn.ATTACK:
                selectManager.CheckSelection();
                if(selectManager.selectedAlly != null && selectManager.selectedOpponent != null)
                {
                    selectManager.selectedOpponent.health -= selectManager.selectedAlly.damage;
                    if (selectManager.selectedOpponent.health <= 0)
                    {
                        opponent.RemoveFieldCard(selectManager.selectedOpponent);
                        Destroy(selectManager.selectedOpponent.gameObject);
                    }
                    selectManager.ResetSelections();
                    turnState = Turn.END_TURN;
                }
                break;

            case Turn.END_TURN:
                if (EndGame())
                {
                    turnState = Turn.END_GAME;
                    selectManager.ResetSelections();
                    //ui.ChangeEndGameUi(winner);
                }
                else
                {
                    EndTurn();
                    ChangeDrawState();
                }
                
                Debug.Log("turn has ended");
                break;
            case Turn.END_GAME:
                
                break;
        }
    }
}
