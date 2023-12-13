using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Default,
    Paused,
    GameOver,
    InMenus
};

public enum Boots {
    Red, Black, Brown, None
};

public enum Hat {
    Red, Brown, Tan, None
};
public class GameManager : MonoBehaviour
{  
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance 
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is NULL");
            
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(this.gameObject);

        // Find pause menu object
        if (pauseMenu == null)
        {
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            if (pauseMenu == null)
            {
                // This should never run
                Debug.Log("GameManager: Cannot find pause menu!");
            }
            Resume();
        }

        // Set state accordingly
        if (SceneManager.GetActiveScene().name.Equals("MainMenuScene"))
        {
            state = GameState.InMenus;
        } else
        {
            state = GameState.Default;
        }

        // Should not need this since we start in menus
        /*if (!started) 
        {
            StartGame();
        }*/
    }
    #endregion

    public Hat hat;
    public Boots boots;
    public GameState state = GameState.Default;
    public bool started = false;
    public GameObject pauseMenu;
    public const string SAVE_FILE_NAME = "/save.json";


    private class SaveObject
    {
        public float timeInSeconds;
        public Hat saveHat;
        public Boots saveBoots;
    }

    // Update is called each frame
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            switch (state)
            {
                case GameState.Default: Pause();
                    break;
                case GameState.Paused: Resume();
                    break;
                // Don't do anything if player hits pause during GameOver or in menus
            }
        }
    }

    public void ChangeHat(Hat newHat) {
        hat = newHat;
    }

    public void ChangeBoots(Boots newBoots) {
        boots = newBoots;
    }

    public void Pause()
    {
        state = GameState.Paused;
        // This will freeze all time-dependent actions
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        if (state != GameState.GameOver)
        {
            state = GameState.Default;
            Time.timeScale = 1f;
        }
        pauseMenu.SetActive(false);
    }

    // Start NEW game
    public void StartGame()
    {
        Debug.Log("Starting Game");
        started = true;
        ChangeBoots(Boots.None);
        ChangeHat(Hat.None);
        state = GameState.Default;
        SceneManager.LoadScene("MainScene");
    }

    public void SaveGame()
    {
        // if started is false, then the timer does not exist and we cannot save
        if (!started || Timer.Instance == null)
        {
            // Display warning
            Debug.Log("Game cannot be saved! Please start the game first!");
            return;
        }
        // Next, query the Timer and create SaveObject
        SaveObject saveObject = new()
        {
            timeInSeconds = Timer.Instance.seconds,
            saveHat = hat,
            saveBoots = boots
        };
        string json = JsonUtility.ToJson(saveObject);
        // Save json to file
        File.WriteAllText(Application.dataPath + SAVE_FILE_NAME, json);
        Debug.Log("Game saved!");
    }

    public void LoadGame()
    {
        // Check if file exists
        if (!File.Exists(Application.dataPath + SAVE_FILE_NAME))
        {
            Debug.Log("Save file does not exist!");
            return;
        }
        string json = File.ReadAllText(Application.dataPath + SAVE_FILE_NAME);
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(json);
        // Add time to timer
        if (Timer.Instance == null)
        {
            Debug.Log("Timer is NULL! Ensure timer is added to main menu scene!");
            return;
        }
        Timer.Instance.seconds = saveObject.timeInSeconds;

        // Equip hat and boots
        hat = saveObject.saveHat;
        boots = saveObject.saveBoots;
        // Start game
        Debug.Log("Starting from save file " + SAVE_FILE_NAME);
        started = true;
        state = GameState.Default;
        SceneManager.LoadScene("MainScene");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void GotoMainMenu()
    {
        state = GameState.InMenus;
        SceneManager.LoadScene("MainMenuScene");
    }
}