using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class DartFly : MonoBehaviour
{
    // A float between 0 and 1 that represents pop chance of balloon
    public float power;
    // Max velocity m/s. v = power*velocityRatio+velocityFloor
    public float velocityRatio;
    // Min velocity m/s
    public float velocityFloor;

    public GameObject dartGameController;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = gameObject.GetComponentInChildren<AudioSource>();
        audioSrc.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Dart velocity is proportional to power
        // +z is forward
        transform.Translate(
            ((power * velocityRatio + velocityFloor) * Time.deltaTime) * Vector3.forward);
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Send collision message to controller
        DartGameController dgc = dartGameController.GetComponent<DartGameController>();
        if (dgc == null)
        {
            Debug.Log("DartFly: DartGameController is NULL on collision");
        } else
        {
            dgc.HandleDartCollision();
        }

        // Assumes Balloon prefab has model as child
        if (collision.gameObject.GetComponentInParent<BalloonPop>() != null)
        {
            BalloonPop bp = collision.gameObject.GetComponentInParent<BalloonPop>();
            if (Random.value <= power)
            {
                bp.Pop();
                // Self destruct
                Destroy(gameObject);
            } else
            {
                // Dart will bounce, turn gravity on and destroy after 5s
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                velocityFloor = 0;
                velocityRatio = 0;
                Destroy(gameObject, 5);
            }
        }
        else if (collision.gameObject.name.Equals("Board"))
        {
            // Stick dart to board
            velocityFloor = 0;
            velocityRatio = 0;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            Destroy(rb);
        }
    }
}
