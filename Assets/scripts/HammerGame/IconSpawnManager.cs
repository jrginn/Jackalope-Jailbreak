using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject trackOneIcon;
    [SerializeField] GameObject trackTwoIcon;

    private float timeIntervalLowerBound = 0.5f;
    private float timeIntervalUpperBound =  2.0f;

    private int trackOneIconCount = 0;
    private int trackTwoIconCount = 0;
    private int trackIconCount = 10;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        trackOneIconCount = 0;
        trackTwoIconCount = 0;
        StartCoroutine(AddTrackOne());
        StartCoroutine(AddTrackTwo());
    }

    IEnumerator AddTrackOne() {
        while (trackOneIconCount <= trackIconCount) {
            Instantiate(trackOneIcon);
            trackOneIconCount++;
            yield return new WaitForSeconds(Random.Range(timeIntervalLowerBound, timeIntervalUpperBound));
        }
    }

    IEnumerator AddTrackTwo() {
        while (trackTwoIconCount <= trackIconCount) {
            yield return new WaitForSeconds(Random.Range(timeIntervalLowerBound, timeIntervalUpperBound));
            Instantiate(trackTwoIcon);
            trackTwoIconCount++;
        }
    }
}
