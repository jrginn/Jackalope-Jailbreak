using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonPop : MonoBehaviour
{
    public GameObject scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pop()
    {
        Destroy(gameObject);
        ScoreCounting sc = scoreCounter.GetComponent<ScoreCounting>();
        sc.Increment();
    }
}
