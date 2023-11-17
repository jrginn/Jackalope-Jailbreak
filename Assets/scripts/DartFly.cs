using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartFly : MonoBehaviour
{
    // A float between 0 and 1 that represents pop chance of balloon
    public float power;
    // Max velocity m/s. v = power*velocityRatio+velocityFloor
    public float velocityRatio;
    // Min velocity m/s
    public float velocityFloor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Dart velocity is proportional to power
        // +z is forward
        transform.Translate(
            ((power * velocityRatio + velocityFloor) * Time.deltaTime) * Vector3.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Balloon"))
        {
            if (Random.value <= power)
            {
                BalloonPop bp = other.GetComponent<BalloonPop>();
                bp.Pop();
            } else
            {
                // Maybe do a bounce effect here?
            }
        }
        else if (other.gameObject.name.Equals("Board"))
        {
            // TODO: Stick dart to board
        }
    }
}
