using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCardStats : MonoBehaviour
{
    //public TextMesh attack;
    private TextMesh health;
    public Card card;

    void Start()
    {
        health = GetComponent<TextMesh>();
    }
    // Update is called once per frame
    void Update()
    {
        health.text = $"Life: {card.health.ToString()}";
    }
}
