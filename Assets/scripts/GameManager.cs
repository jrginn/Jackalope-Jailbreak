using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState {
    Paused, GameOver
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

    public void ChangeHat(Hat newHat) {
        hat = newHat;
    }

    public void ChangeBoots(Boots newBoots) {
        boots = newBoots;
    }
    
}