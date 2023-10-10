using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class StartLine : MonoBehaviour
{
    [SerializeField] bool touchingStartLine = false;

    [SerializeField] private TextMeshProUGUI lap1Text;
    [SerializeField] private TextMeshProUGUI lap2Text;

    [SerializeField] private GameObject P1WinningScreen;
    [SerializeField] private GameObject P2WinningScreen;

    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject GameMenu;

    [SerializeField] private int LapsToWin = 3;
    int Player1Score = 0;
    int Player2Score = 0;


    public void PlayerScored()
    {
        touchingStartLine = true;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (touchingStartLine == true)
        {
            WheelDrive wheelDrive = collision.GetComponent<WheelDrive>();
            while (wheelDrive.Lap == true)
            {
                if (collision.gameObject.name == "Player 1") 
                {
                    Player1Score++;
                    wheelDrive.Lap = false;
                    LapCounter();

                }
                else if (collision.gameObject.name == "Player 2")
                {
                    Player2Score++;
                    wheelDrive.Lap = false;
                    LapCounter();
                }

            }
            Debug.Log(Player1Score);
            Debug.Log(Player2Score);
        }
    }

    public void Update()
    {
        if (Player1Score == LapsToWin)
        {
            P1WinningScreen.SetActive(true);
            PauseMenu.SetActive(true);
            GameMenu.SetActive(false);
        }
        if (Player2Score == LapsToWin)
        {
            P2WinningScreen.SetActive(true);
            PauseMenu.SetActive(true);
            GameMenu.SetActive(false);
        }
    }

    public void LapCounter()
    {
        lap1Text.text = "P1:" + Player1Score.ToString();
        lap2Text.text = "P2:" + Player2Score.ToString();
    }
}
