using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonPop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pop()
    {
        Destroy(gameObject);
        // TODO: Send message to score counter
    }
}
