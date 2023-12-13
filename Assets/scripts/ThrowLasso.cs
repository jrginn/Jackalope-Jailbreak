using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLasso : MonoBehaviour
{

    public GameObject lasso;
    public float launchVelocity = 200f;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch()
    {
        audioSrc.Play();
        GameObject ball = Instantiate(lasso, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
    }
}
