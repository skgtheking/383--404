using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    void Update()
    {
        TitleControl(); 
    }

    void TitleControl()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
