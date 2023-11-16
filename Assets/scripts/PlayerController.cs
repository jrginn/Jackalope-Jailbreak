using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = (horizontal * transform.right) + (vertical * transform.forward);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void IncreaseMoveSpeed(float increase)
    {
        moveSpeed += increase;
    }
}
