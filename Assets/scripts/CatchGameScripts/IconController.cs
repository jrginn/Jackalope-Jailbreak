using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private ConstantForce cf;

    public float strength;


    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        cf = GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * strength;
            cf.force = Vector3.up * Random.Range(-15, -9);
            //rb.AddForce(new Vector3(0, 1000, 0));
            print("Uppies");
        }
    }
}
