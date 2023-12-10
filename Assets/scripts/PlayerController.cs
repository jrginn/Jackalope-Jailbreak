using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lassoRange;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("ThrowLasso");
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

        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) > 150)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal  != 0 || vertical != 0) {
            anim.SetBool("Walking", true);
            Vector3 movement = (horizontal * transform.right) + (vertical * transform.forward);
            movement = movement.normalized * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        } 
        else {
            anim.SetBool("Walking", false);
        }
    }

    void IncreaseMoveSpeed(float increase)
    {
        moveSpeed += increase;
    }
}
