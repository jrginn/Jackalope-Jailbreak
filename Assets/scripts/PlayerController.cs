using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lassoRange;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitdata;
            if (Physics.Raycast(ray, out hitdata, lassoRange))
            {
                if(hitdata.collider.tag.Equals("Jackalope"))
                {
                    SceneManager.LoadScene("CatchScene");
                }
            }
        }
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
