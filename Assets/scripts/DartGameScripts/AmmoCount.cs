using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class AmmoCount : MonoBehaviour
{
    public string counterName;
    public int ammoCount;
    public GameObject dartGameController;

    private DartGameController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = dartGameController.GetComponent<DartGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool DecreaseBy1()
    {
        if (ammoCount < 1)
        {
            return false;
        }
        ammoCount--;
        GetComponent<TextMeshPro>().text = counterName + ammoCount.ToString();
        return true;
    }
}
