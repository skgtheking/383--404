using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

//HelpMenu is Sub-Class
public class helpmenu : GameMenu
{


    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("QuitToMainMenu");
    }

}

