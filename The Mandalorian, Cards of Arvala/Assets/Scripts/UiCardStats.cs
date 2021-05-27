using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCardStats : MonoBehaviour
{
    //public TextMesh attack;
    private TextMesh health;
    public Card card;
    // Start is called before the first frame update
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
