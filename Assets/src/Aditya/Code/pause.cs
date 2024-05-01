using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Importing Pausemenu namespace
using static Pausemenu;

// Main class representing the Pause menu functionality
public class Pausemenu : MonoBehaviour
{
    // Internal class representing the base for Pause menu functionality
    internal class PauseMenuBase
    {
        // Implicit conversion operator from Pausemenu to PauseMenuBase
        public static implicit operator PauseMenuBase(Pausemenu v)
        {
            throw new NotImplementedException();
        }

        // Method to resume the game
        internal void Resume()
        {
            throw new NotImplementedException();
        }
    }

    // Singleton instance of the Pausemenu class
    private static Pausemenu _instance;

    // Property to get the singleton instance of Pausemenu
    public static Pausemenu Instance
    {
        get
        {
            // If instance is null, find and create if necessary
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

    // Flag indicating if the game is paused
    public bool GameisPaused { get; private set; } = false;

    // Reference to the Help menu UI GameObject
    public GameObject HelpMenuUI;

    // Commands for resume and pause actions
    private ICommand resumeCommand;
    private ICommand pauseCommand;

    // Awake method called before Start
    private void Awake()
    {
        // Initialize commands
        resumeCommand = new ResumeCommand(this);
        pauseCommand = new PauseCommand(this);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle between pause and resume based on game state
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

    // Virtual function that can be overridden by subclasses to resume the game
    public void Resume()
    {
        // Hide the Help menu UI
        HelpMenuUI.SetActive(false);
        // Set time scale to normal (unpaused)
        Time.timeScale = 1f;
        // Update pause state
        GameisPaused = false;
    }

    // Method to pause the game
    public void Pause()
    {
        // Show the Help menu UI
        HelpMenuUI.SetActive(true);
        // Set time scale to zero (paused)
        Time.timeScale = 0f;
        // Update pause state
        GameisPaused = true;
    }

    // Method to load the main menu scene
    public void LoadMenu()
    {
        // Log message indicating loading of menu
        Debug.Log("Loading Menu...");
        // Load MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Log message indicating quitting of game
        Debug.Log("Quitting Game..");
        // Load Lose scene
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

