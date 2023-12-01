using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Default,
    Paused,
    GameOver
};

public enum Boots {
    Red, Black, Brown
};

public enum Hat {
    Red, Brown, Tan
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
    }
    #endregion

    public Hat hat;
    public Boots boots;
    public GameState state = GameState.Default;
    public GameObject pauseMenu;

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
                // Don't do anything if player hits pause during GameOver
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

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}