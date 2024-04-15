using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Private class containing scene names and quit method
    private class SceneData
    {
        public const string LoseScene = "Lose";
        public const string GameScene = "SampleScene";

        public static void QuitGame()
        {
            Application.Quit();
        }
    }

    // Method to load the Lose scene
    public void LoadLoseScene()
    {
        SceneManager.LoadScene(SceneData.LoseScene);
    }

    // Method to load the Game scene
    public void LoadGameScene()
    {
        SceneManager.LoadScene(SceneData.GameScene);
    }

    // Method to exit the game
    public void ExitGame()
    {
        SceneData.QuitGame();
    }
}