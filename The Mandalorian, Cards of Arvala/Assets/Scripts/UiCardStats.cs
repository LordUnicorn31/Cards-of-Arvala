using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCardStats : MonoBehaviour
{
    public TextMesh attack;
    public Slider slider;
    public Card card;
    private Color colorToSet = Color.black;

    void Awake()
    {
        slider.maxValue = card.maxHealth;
        slider.value = card.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        attack.text = $"Attack: {card.damage.ToString()}";
        slider.value = card.health;
        if (slider && attack)
        {
            //slider.image.color = colorToSet;
            attack.color = colorToSet;
        }
    }

    public void SetColor(Color color)
    {
        colorToSet = color;
    }
}
