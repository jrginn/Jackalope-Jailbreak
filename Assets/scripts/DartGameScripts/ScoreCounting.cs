using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Require textmeshpro
[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreCounting : MonoBehaviour
{
    public GameObject ammoCounter;
    public string counterName;

    private TextMeshProUGUI _textMeshPro;
    private int _score;
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text = counterName + _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        _textMeshPro.text = counterName + (++_score).ToString();
    }

    public void Decrement()
    {
        _textMeshPro.text = counterName + (--_score).ToString();
    }

    // We need to use a getter here because I want the text to update
    // when score is changed
    public int getScore ()
    {
        return _score;
    }

}
