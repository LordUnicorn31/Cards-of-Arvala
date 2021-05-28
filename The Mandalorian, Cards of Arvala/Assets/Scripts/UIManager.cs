using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject drawCanvas;
    public GameObject playCardCanvas;
    public GameObject attackCanvas;
    public GameObject actionSelectionCanvas;
    private GameObject activeCanvas;
    
    // Start is called before the first frame update
    void Awake()
    {
        drawCanvas.SetActive(false);
        playCardCanvas.SetActive(false);
        attackCanvas.SetActive(false);
        actionSelectionCanvas.SetActive(false);
        drawCanvas.GetComponent<Canvas>().enabled = true;
        playCardCanvas.GetComponent<Canvas>().enabled = true;
        attackCanvas.GetComponent<Canvas>().enabled = true;
        actionSelectionCanvas.GetComponent<Canvas>().enabled = true;
        //first canvas is draw one
        activeCanvas = drawCanvas;
    }

    public void UiDraw()
    {
        activeCanvas.SetActive(false);
        activeCanvas = drawCanvas;
        activeCanvas.SetActive(true);
    }

    public void UiPlay()
    {
        activeCanvas.SetActive(false);
        activeCanvas = playCardCanvas;
        activeCanvas.SetActive(true);
    }

    public void UiAttack()
    {
        activeCanvas.SetActive(false);
        activeCanvas = attackCanvas;
        activeCanvas.SetActive(true);
    }

    public void UiActionSelection()
    {
        activeCanvas.SetActive(false);
        activeCanvas = actionSelectionCanvas;
        activeCanvas.GetComponent<ActionSelectionCanvas>().StartActionSelection();
        activeCanvas.SetActive(true);
    }

    public void DisableAllUi()
    {
        activeCanvas.SetActive(false);
    }
}