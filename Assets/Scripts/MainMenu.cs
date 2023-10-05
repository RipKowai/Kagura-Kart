using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void BackToMainMenu()
    {
        if (level1 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            level1 = false;
        }
        if (level2 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            level2 = false;
        }
        if (level3 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
            level3 = false;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
