using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePowerup : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject[] UIHat;
    public Hat displayedHat;
    [SerializeField] GameObject[] UIBoots;
    public Boots displayedBoots;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        displayedBoots = Boots.None;
        displayedHat = Hat.None;
    }

    // Update is called once per frame
    void Update()
    {
        Hat currentHat = gameManager.hat;
        if (displayedHat != currentHat)
            ChangeHat(currentHat);
        
        Boots currentBoots = gameManager.boots;
        if (displayedBoots != currentBoots)
            ChangeBoots(currentBoots);
    }

    public void ChangeHat(Hat newHat) {
        for (int i = 0; i < UIHat.Length; i++) {
            UIHat[i].SetActive(false);
        }
        
        if (newHat == Hat.Tan)
            UIHat[0].SetActive(true);
        else if (newHat == Hat.Brown)
            UIHat[1].SetActive(true);
        else if (newHat == Hat.Red)
            UIHat[2].SetActive(true);
    
        displayedHat = newHat;
    }

    public void ChangeBoots(Boots newBoots) {
        for (int i = 0; i < UIBoots.Length; i++) {
            UIBoots[i].SetActive(false);
        }
        
        if (newBoots == Boots.Brown)
            UIBoots[0].SetActive(true);
        else if (newBoots == Boots.Black)
            UIBoots[1].SetActive(true);
        else if (newBoots == Boots.Red)
            UIBoots[2].SetActive(true);

        displayedBoots = newBoots;
    }
}
