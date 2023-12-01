using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class AmmoCount : MonoBehaviour
{
    public string counterName;
    public int ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = counterName + ammoCount.ToString();
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
        GetComponent<TextMeshProUGUI>().text = counterName + (--ammoCount).ToString();
        return true;
    }
}
