using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject GameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void GameOver()
    {
        GameOverUI.SetActive(true);
    }
    */
    public void Restart() {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Restart");
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quit");
    }

}
