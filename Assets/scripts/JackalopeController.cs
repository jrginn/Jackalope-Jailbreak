using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackalopeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(150, 210);
        transform.RotateAround(transform.position, Vector3.up, angle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 vec = transform.forward.normalized * moveSpeed * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(vec + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Ground"))
        {
            angle = Random.Range(150, 210);
            transform.Rotate(Vector3.up, angle);
        }
    }
}
