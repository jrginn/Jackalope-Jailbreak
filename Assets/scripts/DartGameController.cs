using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * State machine to handle the dart game loop
 */

public enum GameState
{
    Aiming,
    SelectingPower,
    Ending
}
public class DartGameController : MonoBehaviour
{
    public GameState state;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.Aiming;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
