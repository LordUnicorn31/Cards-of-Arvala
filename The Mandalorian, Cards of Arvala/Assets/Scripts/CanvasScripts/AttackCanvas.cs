using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCanvas : MonoBehaviour
{
    public GameLoop game;
    public Button playCardButton;
    public Button attackButton;
    // Start is called before the first frame update
    void Start()
    {
        //Reset the ui when enabling the canvas
        playCardButton.interactable = true;
        attackButton.interactable = true;
        if (game.turnPlayer.FullField() || game.turnPlayer.EmptyHand())
            playCardButton.interactable = false;
        if (game.turnPlayer.EmptyField())
            attackButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
