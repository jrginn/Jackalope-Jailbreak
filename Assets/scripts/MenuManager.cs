using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject howMenu;
    [SerializeField] GameObject aboutMenu;

    private bool howToPlay = false;
    private bool about = false;

    private bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        howToPlay = false;
        about = false;
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePause()
    {
        pause = !pause;
        pauseMenu.gameObject.SetActive(pause);
    }

    public void ToggleHowToPlay() 
    {
        howToPlay = !howToPlay;
        howMenu.gameObject.SetActive(howToPlay);
        aboutMenu.gameObject.SetActive(false);
    }

    public void ToggleAbout()
    {
        about = !about;
        aboutMenu.gameObject.SetActive(!about);
        howMenu.gameObject.SetActive(false);
    }
}
