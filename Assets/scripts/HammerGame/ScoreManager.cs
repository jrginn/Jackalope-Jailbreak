using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject iconSpawnManager;
    [SerializeField] GameObject canvas;
    [SerializeField] PlayableDirector hammerTimeline;
    [SerializeField] PlayableDirector badTimeline;
    [SerializeField] PlayableDirector goodTimeline;
    [SerializeField] PlayableDirector greatTimeline;
    [SerializeField] AudioSource audioSrc;


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

        // Timelines
        hammerTimeline.Stop();
        badTimeline.Stop();
        goodTimeline.Stop();
        greatTimeline.Stop();
        hammerTimeline.time = 0;
        badTimeline.time = 0;
        goodTimeline.time = 0;
        greatTimeline.time = 0;
    }

    public void AddScore(int scoreToAdd) 
    {
        score += scoreToAdd;
    }

    public IEnumerator FinishGame()
    {
        hammerTimeline.Play();
        float seconds = (float)hammerTimeline.duration;
        yield return new WaitForSeconds(seconds);
        canvas.SetActive(true);
        // total possible score is 40
        if (score < 15) {
            Debug.Log("Bad Item");
            finalItem = Hat.Tan;
            badTimeline.Play();
        }
        else if (score <= 30) {
            Debug.Log("Good Item");
            finalItem = Hat.Brown;
            goodTimeline.Play();
        }
        else {
            Debug.Log("Great Item");
            finalItem = Hat.Red;
            audioSrc.Play();
            greatTimeline.Play();
        }
    }

    public void Done() {
        GameObject.Find("GameManager").GetComponent<GameManager>().ChangeHat(finalItem);
        SceneManager.LoadScene("MainScene");
    }
}
