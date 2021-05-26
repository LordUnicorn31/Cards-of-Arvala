using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public int damage;
    [HideInInspector]public int id = -1;
    [HideInInspector]public int player = 0;
    public GameLoop game;
    // Start is called before the first frame update
    void Start()
    {
        game.TakeCard(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
