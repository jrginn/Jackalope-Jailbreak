using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{

    public float moveSpeed;
    private float direction;
    public float swapTime;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.Instance;
        switch (gm.hat)
        {
            case Hat.Red:
                transform.localScale += Vector3.up * .3f;
                break;
            case Hat.Brown:
                transform.localScale += Vector3.up * .2f;
                break;
            case Hat.Tan:
                transform.localScale += Vector3.up * .1f;
                break;
            default:
                break;
        }

        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * direction;
        timer += Time.deltaTime;
        if(timer >= swapTime)
        {
            direction *= -1;
            timer = 0;
        }
    }
}
