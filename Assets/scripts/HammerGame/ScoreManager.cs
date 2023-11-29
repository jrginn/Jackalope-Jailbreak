using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject iconSpawnManager;
    [SerializeField] GameObject canvas;
    public int score = 0;
    
    private Hat finalItem;

    // Start is called before the first frame update
    void Start()
    {
        TryAgain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain() 
    {
        score = 0;
        finalItem = Hat.Tan;
        iconSpawnManager.GetComponent<IconSpawnManager>().Restart();
        canvas.SetActive(false);
    }

    public void AddScore(int scoreToAdd) 
    {
        score += scoreToAdd;
    }

    public void FinishGame()
    {
        canvas.SetActive(true);
        // total possible score is 40
        if (score < 15) {
            Debug.Log("Bad Item");
            finalItem = Hat.Tan;
        }
        else if (score <= 30) {
            Debug.Log("Good Item");
            finalItem = Hat.Brown;
        }
        else {
            Debug.Log("Great Item");
            finalItem = Hat.Red;
        }
    }

    public void Done() {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeHat(finalItem);
        SceneManager.LoadScene("MainScene");
    }
}
