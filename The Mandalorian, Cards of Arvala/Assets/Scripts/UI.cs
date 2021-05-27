using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [HideInInspector] public Text text1;
    // Start is called before the first frame update
    void Start()
    {
        text1 = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UiDraw()
    {
        text1.color = Color.blue;
        text1.text = $"Draw a card";
    }

    public void UiPlay()
    {
        text1.color = Color.magenta;
        text1.text = $"Play a card";
    }

    public void UiAttack()
    {
        text1.color = Color.yellow;
        text1.text = $"Attack a card";
    }

    //void UiDraw2()
    //{
    //    text.text = $"Player 2 draws a card";
    //}

}
