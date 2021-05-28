using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCardStats : MonoBehaviour
{
    public TextMesh health;
    public TextMesh attack;
    public Card card;

    // Update is called once per frame
    void Update()
    {
        health.text = $"Life: {card.health.ToString()}";
        attack.text = $"Attack: {card.damage.ToString()}";
    }
}
