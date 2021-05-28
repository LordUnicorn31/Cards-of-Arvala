using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    public Text winnerText;
    // Start is called before the first frame update
    public void SetWinnerText(Player winner)
    {
        winnerText.text = winner.playerName;
    }
}
