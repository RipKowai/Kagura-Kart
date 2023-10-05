using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapCounter : StartLine
    {
        [SerializeField] private TextMeshProUGUI lap1Text;
        [SerializeField] private TextMeshProUGUI lap2Text;
    /*
        void UpdateScore()
        {
            lap1Text.text = "P1: " + Player1Score.ToString();
            lap2Text.text = "P2: " + Player2Score.ToString();
        }*/
    }

