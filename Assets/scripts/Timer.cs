using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    #region Singleton
    private static Timer _instance;
    public static Timer Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Timer is NULL");

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public float seconds = 0;
    public int totalMins = 5;
    public TextMeshProUGUI timeText;
    private GameObject timerGO;
    private float totalSeconds;

    // Start is called before the first frame update
    void Start()
    {
        totalSeconds = totalMins * 60;
        DontDestroyOnLoad(gameObject);
        getTimeText();
    }

    // Update is called once per frame
    void Update()
    {
        // If we are in menus DO NOT increment timer
        if (GameManager.Instance.state == GameState.InMenus)
        {
            return;
        }
        if (seconds < totalSeconds)
        {
            seconds += Time.deltaTime;
        }
        else
        {
            seconds = 0;
            SceneManager.LoadScene("LossScene");
        }
        if (timeText == null)
        {
            getTimeText();        
        }

        if (timeText != null)
        {
            DisplayTime(seconds);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = totalMins - 1 - Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = 59 - Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = 999 - (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    private void getTimeText()
    {
        timerGO = GameObject.FindGameObjectWithTag("TimerText");
        if (timerGO != null)
        {
            timeText = timerGO.GetComponent<TextMeshProUGUI>();
        }
    }
}
