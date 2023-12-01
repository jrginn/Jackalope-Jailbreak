using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private ConstantForce cf;

    public float strength;

    private float score;
    private float loseCon;
    private float forceTimer;
    private bool inZone;

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
            forceTimer += Time.deltaTime;
            if(forceTimer >= 3)
            {
                cf.force = Vector3.up * Random.Range(-15, -9);
            }
        }

        if (inZone)
        {
            score += Time.deltaTime;
        }
        else
        {
            loseCon += Time.deltaTime;
        }

        if (score >= 7 && score < 7.1)
        {
            SceneManager.LoadScene("VictoryScene");
        }
        
        if (loseCon >= 10 && loseCon < 10.1)
        {
            SceneManager.LoadScene("MainScene");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        inZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inZone = false;
    }
}
