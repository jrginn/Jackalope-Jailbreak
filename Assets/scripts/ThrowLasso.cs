using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLasso : MonoBehaviour
{

    public GameObject lasso;
    public float launchVelocity = 200f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = Instantiate(lasso, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        }
    }
}
