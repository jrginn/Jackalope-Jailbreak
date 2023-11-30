using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * State machine to handle the dart game loop
 */

public enum DartGameState
{
    Aiming,
    SelectingPower,
    Ending
}
public class DartGameController : MonoBehaviour
{
    public DartGameState state;
    // Start is called before the first frame update
    void Start()
    {
        state = DartGameState.Aiming;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == DartGameState.Ending)
        {
            //Time.
        }
    }
}
