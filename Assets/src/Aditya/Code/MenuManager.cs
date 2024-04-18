using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yaSingleton;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "MenuManager", menuName = "Systems/MenuManager")]
public class MenuMANGAER : Singleton<MenuMANGAER>
{



    //public GameObject HelpMenuPrefab;

    public GameObject pauseMenuPrefab;

    public GameObject canvasPrefab;

    public GameObject MainMenu;

    private Canvas _canvas;

    private List<GameMenu> activeMenus;

    protected override void Initialize()
    {
        base.Initialize();
        activeMenus = new List<GameMenu>();
    }

    private Canvas SceneCanvas
    {

        get
        {

            //Check if canvas variable is set
            if (_canvas == null)
            {
                //If not set, look in scene for canvas
                _canvas = FindObjectOfType<Canvas>();

                if (_canvas == null)
                {

                    //If no canvas in scene, create one
                    _canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();

                }

            }


            return _canvas;

        }


    }


    private GameObject HelpMenuInstance;
    private bool isGamePaused;

    public void CreateMenu(GameMenu menu)
    {
        //Checking to see if one exists
        //Create a new game menu
        GameObject newMenu = Instantiate(menu.gameObject, SceneCanvas.transform);
        GameMenu menuComponent = newMenu.GetComponent<GameMenu>();
        System.Type type = menuComponent.GetType();

        if (type == typeof(HelpMenu))
        {
            AddHelpMenuFunctionality((HelpMenu)menuComponent);
        }





        //assign functionality to the buttons
        menuComponent.destroyMenuButton.onClick.AddListener(
           delegate { DestroyMenu(menu); }
           );


        activeMenus.Add(menu);

    }

    private void AddHelpMenuFunctionality(HelpMenu menuComponent)
    {
        throw new NotImplementedException();
    }

    public void DestroyMenu(GameMenu menu)
    {
        if (menu == null)
        {
            activeMenus.Remove(menu);
            Destroy(menu.gameObject);

        }
    }
    /// <summary>
    /// checking if the prefab has a Gamemenu script.abstract
    /// if so, then the instantiate 
    /// </summary>
    /// <param name="prefab"></param>
    private void ValidateAndCreateMenuPrefab(GameObject prefab)
    {
        //Escape is down
        GameMenu menu = pauseMenuPrefab.GetComponent<GameMenu>();
        if (menu != null)
        {
            CreateMenu(menu);

        }
        else
        {
            Debug.LogError("Pause Menu Prefab has no GameMenu script attached to it.");
        }


    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            bool exists = false;
            foreach (GameMenu menu in activeMenus)
            {
                if (menu.GetType() == typeof(HelpMenu))
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                //Escape is down
                ValidateAndCreateMenuPrefab(pauseMenuPrefab);
            }


        }



    }

    private void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        isGamePaused = true; // Set the flag to indicate that the game is paused
    }

    private void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        isGamePaused = false; // Reset the flag
    }
}



internal class HelpMenu
{
    public static explicit operator HelpMenu(GameMenu v)
    {
        throw new NotImplementedException();
    }
}