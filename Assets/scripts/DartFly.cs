using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartFly : MonoBehaviour
{
    // A float between 0 and 1 that represents pop chance of balloon
    public float power;
    // Max velocity m/s. v = power*velocityRatio
    public float velocityRatio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Dart velocity is proportional to power
        // +z is forward
        transform.Translate((power * velocityRatio * Time.deltaTime) * Vector3.forward);

        // Handle collision

    }
}
