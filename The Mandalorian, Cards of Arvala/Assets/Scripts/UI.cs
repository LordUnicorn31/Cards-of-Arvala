using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    [HideInInspector] public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UiDraw()
    {
        text.text = $"Draw a card";
    }

    public void UiPlay()
    {
        text.text = $"Play a card";
    }

    public void UiAttack()
    {
        text.text = $"Attack a card";
    }

    //void UiDraw2()
    //{
    //    text.text = $"Player 2 draws a card";
    //}

}
