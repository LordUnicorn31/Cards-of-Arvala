using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public int damage;
    [HideInInspector]public int player = 0;
    public GameLoop game;
    [HideInInspector]public bool registered = false;

    public void DetectedCard()
    {
        if (!registered)
            game.DetectedNewCard(this);
        else
            game.DetectedRegisteredCard(this);
    }
}
