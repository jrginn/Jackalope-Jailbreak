using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float track;
    private KeyCode key;
    private float speed = 25;
    public float zBound;
    public Vector3 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        if (track == 1) {
            key = KeyCode.A;
        }
        else {
            key = KeyCode.D;
        }

        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        moveDownTrack();
    }

    private void moveDownTrack() {
        if (transform.position.z < zBound) {
            Destroy(gameObject);
        }
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(key))
        { 
            if (other.name == "PerfectCollider") 
            {
                Debug.Log("Perfect");
                Destroy(gameObject);
            } else {
                Debug.Log("Okay");
                Destroy(gameObject);
            }
        }
    }
}
