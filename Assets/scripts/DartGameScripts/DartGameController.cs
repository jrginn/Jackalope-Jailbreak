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
    public GameObject ammoCounter;

    private AmmoCount _ac;
    // Start is called before the first frame update
    void Start()
    {
        state = DartGameState.Aiming;
        if (ammoCounter.GetComponent<AmmoCount>() != null )
        {
            _ac = ammoCounter.GetComponent<AmmoCount>();
        } else
        {
            Debug.Log("DartGameController: AmmoCount is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // We have to use this to ensure that darts are allowed to collide when ammo = 0
    public void HandleDartCollision()
    {
        if (_ac.ammoCount == 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {

    }
}
