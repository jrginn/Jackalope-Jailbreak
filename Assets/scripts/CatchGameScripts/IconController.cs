using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconController : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    private ConstantForce cf;

    [SerializeField] Animator anim;

    public float strength;

    private float score;
    private float loseCon;
    private float forceTimer;
    private bool inZone;

    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip struggle;
    [SerializeField] AudioClip emote;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        cf = GetComponent<ConstantForce>();
        anim.SetBool("Struggle", true);
        audioSrc.PlayOneShot(struggle);

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
                forceTimer = 0;
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
            StartCoroutine(LoseGame());
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

    IEnumerator LoseGame() {
        anim.SetTrigger("Emote");
        audioSrc.PlayOneShot(emote);
        yield return new WaitForSeconds(1.06f);
        anim.SetBool("Struggle", false);
        SceneManager.LoadScene("MainScene");
    }
}
