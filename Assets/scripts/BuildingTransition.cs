using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingTransition : MonoBehaviour
{
    [SerializeField]
    private bool hasGame;
    [SerializeField]
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        hasGame = false;
        sceneName = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!sceneName.Equals(""))
        {
            hasGame = true;
        }
        if (hasGame && collision.collider.CompareTag("Player"))
        {
            Debug.Log("Loading into minigame " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }

    public void LoadMinigame(string minigame)
    {
        hasGame = true;
        sceneName = minigame;
    }
}
