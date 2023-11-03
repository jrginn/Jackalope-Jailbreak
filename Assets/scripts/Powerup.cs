using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public string aspect;
    public float increase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player");
        player.SendMessage(aspect, increase);
    }
}
