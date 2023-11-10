using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public enum GameState {
        Paused, GameOver
    };

    public enum Lasso {
        Golden, Normal, Ratty
    };

    public enum Boots {
        Red, Black, Brown
    };

    public enum Hat {
        Red, Brown, Tan
    };

}