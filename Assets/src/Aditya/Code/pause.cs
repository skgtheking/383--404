using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{

    public static bool GameisPaused = false;

    public GameObject HelpMenuUI;

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
    void Resume()
    {
        HelpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;


    }

    void Pause()
    {
        HelpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

}