using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [HideInInspector] public Card selectedAlly = null;
    [HideInInspector] public Card selectedOpponent = null;
    public GameLoop game;
    // Start is called before the first frame update
    public void CheckSelection()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Card hitCard = hit.transform.gameObject.GetComponent<Card>();
                    if(hitCard)
                    {
                        if(game.turnPlayer.CardOnField(hitCard))
                        {
                            selectedAlly = hitCard;
                            selectedAlly.OutlineCard(true);
                        }
                        else if(game.opponent.CardOnField(hitCard))
                        {
                            selectedOpponent = hitCard;
                            selectedOpponent.OutlineCard(true);
                        }
                    }
                }
            }
        }
    }
    public void ResetSelections()
    {
        if (selectedAlly)
        {
            selectedAlly.OutlineCard(false);
            selectedAlly = null;
        }

        if (selectedOpponent)
        {
            selectedAlly.OutlineCard(false);
            selectedOpponent = null;
        }
    }
}
