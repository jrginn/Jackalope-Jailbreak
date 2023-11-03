using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Require textmeshpro
[RequireComponent(typeof(TextMeshPro))]
public class ScoreCounting : MonoBehaviour
{
    private TextMeshPro _textMeshPro;
    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void increment()
    {
        _textMeshPro.text = _score++.ToString();
    }

    void decrement()
    {
        _textMeshPro.text = _score--.ToString();
    }
}
