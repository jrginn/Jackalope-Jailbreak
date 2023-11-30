using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject scoreManager;
    [SerializeField] GameObject trackOneIcon;
    [SerializeField] GameObject trackTwoIcon;

    private float timeIntervalLowerBound = 0.5f;
    private float timeIntervalUpperBound =  2.0f;

    private int trackOneIconCount = 0;
    private int trackTwoIconCount = 0;
    private int trackIconCount = 10;
    public bool trackOneOn = true;
    public bool trackTwoOn = true;
    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!trackOneOn && !trackTwoOn && on) {
            on = false;
            StartCoroutine(Finish());
        }
    }

    public void Restart() {
        trackOneIconCount = 0;
        trackTwoIconCount = 0;
        trackOneOn = true;
        trackTwoOn = true;
        StartCoroutine(AddTrackOne());
        StartCoroutine(AddTrackTwo());
        on = true;
    }

    IEnumerator AddTrackOne() {
        while (trackOneIconCount <= trackIconCount) {
            Instantiate(trackOneIcon);
            trackOneIconCount++;
            yield return new WaitForSeconds(Random.Range(timeIntervalLowerBound, timeIntervalUpperBound));
        }
        trackOneOn = false;
    }

    IEnumerator AddTrackTwo() {
        while (trackTwoIconCount <= trackIconCount) {
            yield return new WaitForSeconds(Random.Range(timeIntervalLowerBound, timeIntervalUpperBound));
            Instantiate(trackTwoIcon);
            trackTwoIconCount++;
        }
        trackTwoOn = false;
    }

    IEnumerator Finish() {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(scoreManager.GetComponent<ScoreManager>().FinishGame());
    }
}
