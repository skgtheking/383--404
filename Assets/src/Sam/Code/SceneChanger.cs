using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void loseScene()
    {
        SceneManager.LoadScene("Lose");
    }

    public void gameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
