using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI playerLapText;
    public TextMeshProUGUI player2LapText;
    private int playerLap;
    private int player2Lap;

    public void PlayerScores()
    {
        playerLap++;
        this.playerLapText.text = playerLap.ToString();

        Debug.Log(playerLap);
    }

    public void Player2Scores()
    {
        player2Lap++;
        Debug.Log(player2Lap);

        this.player2LapText.text = player2Lap.ToString();
    }
}
