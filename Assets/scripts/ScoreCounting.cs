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

    public void Increment()
    {
        _textMeshPro.text = _score++.ToString();
    }

    public void Decrement()
    {
        _textMeshPro.text = _score--.ToString();
    }
}
