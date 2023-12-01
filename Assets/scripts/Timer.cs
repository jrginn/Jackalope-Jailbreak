using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        timeText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if (seconds < 600)
        {
            seconds += Time.deltaTime;
        }
        else
        {
            seconds = 0;
            SceneManager.LoadScene("LossScene");
        }
        if (SceneManager.GetActiveScene().name.Equals("MainScene"))
        {
            if (timeText == null)
            {
                timeText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();
            }
            DisplayTime(seconds);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = 9 - Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = 59 - Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = 999 - (timeToDisplay % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
