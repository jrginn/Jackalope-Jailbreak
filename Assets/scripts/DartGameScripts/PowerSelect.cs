using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSelect : MonoBehaviour
{
    public GameObject controller;
    public GameObject crosshair;
    public float velocityScale;

    // Band values
    public float greenMin = 0.4f;
    public float greenLen = 0.2f;
    public float yellowLen = 0.2f;

    private Slider slider;
    private float currDir;
    private DartGameController _controllerScript;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        _controllerScript = controller.GetComponent<DartGameController>();
        currDir = 1f;
        // Self-disable on start, only activate when called
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (_controllerScript.state == DartGameState.SelectingPower)
        {
            if (slider.normalizedValue <= 0 || slider.normalizedValue >= 1)
            {
                currDir *= -1;
            }

            // Eq: v = scale*cos^2(slider.value)* (+-1)
            // I like cos^2 better as it makes it a little more difficult
            slider.value += velocityScale *
            Mathf.Cos(slider.value) * Mathf.Cos(slider.value) * currDir;
            if (Input.GetButtonDown("Fire1"))
            {
                _controllerScript.state = DartGameState.Aiming;
                crosshair.GetComponent<DartShoot>().SpawnDart(GetPower());
                gameObject.SetActive(false);
            }
        }
    }

    /**
     * Returns a float between 0 and 1 that represents
     * the probability of popping a balloon
     * 
     */
    public float GetPower()
    {
        float norm = slider.normalizedValue;
        if (norm < greenMin - yellowLen || norm > greenMin + greenLen + yellowLen)
        {
            // In red band
            return 0;
        }
        if (norm > greenMin && norm < greenMin + greenLen)
        {
            // In green band
            return 1;
        }
        // Else, in yellow band
        // I can't do math so right now just return 0.5
        return 0.5f;
    }
}
