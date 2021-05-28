using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector] public int health;
    public int damage;
    [HideInInspector] public int player = 0;
    public GameLoop game;
    private bool registered = false;
    public GameObject cardPrefab;
    private bool showModel = false;
    public UiCardStats cardUi;

    void Awake()
    {
        health = maxHealth;
        cardUi.enabled = false;
        gameObject.GetComponentInChildren<Outline>().enabled = true;
        gameObject.GetComponentInChildren<Outline>().enabled = false;
        cardPrefab.SetActive(false);
    }

    public void DetectedCard()
    {
        if (!registered)
            game.DetectedNewCard(this);
        else
            game.DetectedRegisteredCard(this);
    }

    public void OutlineCard(bool outline)
    {
        gameObject.GetComponentInChildren<Outline>().enabled = outline;
    }
    public void RegisterCard()
    {
        if(!registered)
        {
            registered = true;
        }
    }

    public void ShowModel(bool show)
    {
        if (show != showModel)
        {
            showModel = show;
            cardPrefab.SetActive(showModel);
            if (showModel)
                cardUi.enabled = true;
            else
                cardUi.enabled = false;
        }
    }
}
