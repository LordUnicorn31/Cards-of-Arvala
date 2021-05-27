using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas drawCanvas;
    public Canvas playCardCanvas;
    public Canvas attackCanvas;
    [HideInInspector] public Canvas activeCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        drawCanvas.enabled = false;
        playCardCanvas.enabled = false;
        attackCanvas.enabled = false;

        //first canvas is draw one
        activeCanvas = drawCanvas;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UiDraw()
    {
        activeCanvas.enabled = false;
        activeCanvas = drawCanvas;
        activeCanvas.enabled = true;
    }

    public void UiPlay()
    {
        activeCanvas.enabled = false;
        activeCanvas = playCardCanvas;
        activeCanvas.enabled = true;
    }

    public void UiAttack()
    {
        activeCanvas.enabled = false;
        activeCanvas = attackCanvas;
        activeCanvas.enabled = true;
    }

    //void UiDraw2()
    //{
    //    text.text = $"Player 2 draws a card";
    //}

}