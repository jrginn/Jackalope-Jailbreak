using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject howMenu;
    [SerializeField] GameObject aboutMenu;

    private bool howToPlay;
    private bool about;

    // Start is called before the first frame update
    void Start()
    {
        howToPlay = false;
        about = false;
    }

    // Update is called once per frame
    void Update()
    {

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

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void LoadGame()
    {
        GameManager.Instance.LoadGame();
    }

    public void SaveGame()
    {
        GameManager.Instance.SaveGame();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
