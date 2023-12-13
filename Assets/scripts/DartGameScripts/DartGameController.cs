using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * State machine to handle the dart game loop
 */

public enum DartGameState
{
    Aiming,
    SelectingPower,
    Ending
}
public class DartGameController : MonoBehaviour
{
    public DartGameState state;
    public GameObject ammoCounter;
    public GameObject scoreCounter;
    public GameObject endGameMenu;
    public int tier3Min;
    public int tier2Min;



    private AmmoCount _ammoScript;
    private ScoreCounting _scoreScript;
    private Boots _finalItem;
    // Start is called before the first frame update
    void Start()
    {
        _finalItem = Boots.Brown;
        state = DartGameState.Aiming;
        if (ammoCounter.GetComponent<AmmoCount>() != null )
        {
            _ammoScript = ammoCounter.GetComponent<AmmoCount>();
        } else
        {
            Debug.Log("DartGameController: AmmoCount is NULL");
        }

        if (scoreCounter.GetComponent<ScoreCounting>() != null )
        {
            _scoreScript = scoreCounter.GetComponent<ScoreCounting>();
        } else
        {
            Debug.Log("DartGameController: AmmoCount is NULL");
        }

        endGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // We have to use this to ensure that darts are allowed to collide when ammo = 0
    public void HandleDartCollision()
    {
        if (_ammoScript.ammoCount == 0)
        {
            EndGame();
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void EndGame()
    {
        // Evaluate winning condition
        int score = _scoreScript.getScore();
        if (score >= tier3Min)
        {
            // Assign tier 3 item
            _finalItem = Boots.Red;
        } else if (score >= tier2Min)
        {
            // Assign tier 2 item
            _finalItem = Boots.Black;
        } else
        {
            // Assign tier 1 item
            _finalItem = Boots.Brown;
        }

        GameManager.Instance.ChangeBoots(_finalItem);

        endGameMenu.SetActive(true);
    }
}
