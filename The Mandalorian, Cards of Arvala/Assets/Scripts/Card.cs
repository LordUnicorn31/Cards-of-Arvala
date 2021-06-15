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
    [HideInInspector] public bool dead = false;
    private bool superDead = false;
    public UiCardStats cardUi;
    public Animator anim;
    private float deathTimer = 8.0f;

    void Awake()
    {
        health = maxHealth;
        cardUi.enabled = false;
        gameObject.GetComponentInChildren<Outline>().enabled = true;
        gameObject.GetComponentInChildren<Outline>().enabled = false;
        cardPrefab.SetActive(false);
    }

    private void Update()
    {
        if(dead && !superDead)
        {
            deathTimer -= Time.deltaTime;
            if(deathTimer < 0.0f)
            {
                ShowModel(false);
                superDead = true;
            }
        }
    }
    public void DetectedCard()
    {
        if (dead)
            return;

        if (!registered)
            game.DetectedNewCard(this);
        else
        {
            if (showModel)
            {
                cardUi.gameObject.SetActive(true);
                cardUi.enabled = true;
            }
            game.DetectedRegisteredCard(this);
        }
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
            {
                cardUi.gameObject.SetActive(true);
                cardUi.enabled = true;
            }
            else
            {
                cardUi.gameObject.SetActive(false);
                cardUi.enabled = false;
            }
        }
    }

    public void CardDeath()
    {
        dead = true;
    }

    public void ChangeOutlineColor(Color color)
    {
        Outline outline = gameObject.GetComponentInChildren<Outline>();
        if(outline && outline.enabled)
        {
            outline.OutlineColor = color;
        }
    }
}
