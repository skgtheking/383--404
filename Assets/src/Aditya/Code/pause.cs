using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Pausemenu;

public class Pausemenu : MonoBehaviour


{

    internal class PauseMenuBase
    {
        public static implicit operator PauseMenuBase(Pausemenu v)
        {
            throw new NotImplementedException();
        }

        internal void Resume()
        {
            throw new NotImplementedException();
        }
    }
    private static Pausemenu _instance;

    public static Pausemenu Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Pausemenu>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Pausemenu>();
                    singletonObject.name = typeof(Pausemenu).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    public bool GameisPaused { get; private set; } = false;

    public GameObject HelpMenuUI;

    private ICommand resumeCommand;
    private ICommand pauseCommand;

    private void Awake()
    {
        // Initialize commands
        resumeCommand = new ResumeCommand(this);
        pauseCommand = new PauseCommand(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                resumeCommand.Execute();
            }
            else
            {
                pauseCommand.Execute();
            }
        }
    }

    // Virtual function that can be overridden by subclasses
    public virtual void Resume()
    {
        HelpMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Pause()
    {
        HelpMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game..");
        SceneManager.LoadScene("Lose");
    }
}

// Command interface
public interface ICommand
{
    void Execute();
}

// Concrete command for resuming the game
public class ResumeCommand : ICommand
{
    private Pausemenu pauseMenu;

    public ResumeCommand(Pausemenu pauseMenu)
    {
        this.pauseMenu = pauseMenu;
    }

    public void Execute()
    {
        pauseMenu.Resume();
    }
}

// Concrete command for pausing the game
public class PauseCommand : ICommand
{
    private Pausemenu pauseMenu;

    public PauseCommand(Pausemenu pauseMenu)
    {
        this.pauseMenu = pauseMenu;
    }

    public void Execute()
    {
        pauseMenu.Pause();
    }
}

// Main class
public class MainClass : MonoBehaviour
{
    void Start()
    {
        // Dynamically bound method call
        PauseMenuBase dynamicMenu = new Pausemenu(); // Static type is PauseMenuBase, dynamic type is Pausemenu
        dynamicMenu.Resume(); // Calls Resume() from Pausemenu (dynamic binding)
    }
}

