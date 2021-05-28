using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSelectionCanvas : MonoBehaviour
{
    public GameLoop game;
    public Button playCardButton;
    public Button combatButton;
    // Start is called before the first frame update
    void Start()
    {
        //Reset the ui when enabling the canvas
        playCardButton.interactable = true;
        combatButton.interactable = true;
        if (game.turnPlayer.FullField() || game.turnPlayer.EmptyHand())
            playCardButton.interactable = false;
        if (game.turnPlayer.EmptyField())
            combatButton.interactable = false;
    }
}
