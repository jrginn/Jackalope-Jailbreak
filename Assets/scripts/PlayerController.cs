using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lassoRange;
    public GameObject lassoSpawn;
    public float delay = 1f;

    private bool canThrow;

    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        canThrow = true;

        GameManager gm = GameManager.Instance;
        switch(gm.boots)
        {
            case Boots.Red:
                moveSpeed = 21f;
                break;
            case Boots.Black:
                moveSpeed = 18f;
                break;
            case Boots.Brown:
                moveSpeed = 15f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            anim.SetTrigger("ThrowLasso");
            lassoSpawn.GetComponent<ThrowLasso>().Launch();
            canThrow = false;
            StartCoroutine(ThrowDelay());
            /**
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitdata;
            if (Physics.Raycast(ray, out hitdata, lassoRange))
            {
                if(hitdata.collider.tag.Equals("Jackalope"))
                {
                    SceneManager.LoadScene("CatchScene");
                }
            }
            **/

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

    IEnumerator ThrowDelay()
    {
        yield return new WaitForSeconds(delay);
        canThrow = true;
    }
}
