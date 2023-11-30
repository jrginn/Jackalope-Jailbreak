using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Require textmeshpro
[RequireComponent(typeof(TextMeshPro))]
public class ScoreCounting : MonoBehaviour
{
    public GameObject ammoCounter;
    public GameObject dartGameController;

    private TextMeshPro _textMeshPro;
    private int _score;
    private AmmoCount _count;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _count = ammoCounter.GetComponent<AmmoCount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increment()
    {
        _textMeshPro.text = _score++.ToString();
        if (_count.ammoCount == 0)
        {
            dartGameController.GetComponent<DartGameController>().state = DartGameState.Ending;
        }
    }

    public void Decrement()
    {
        _textMeshPro.text = _score--.ToString();
    }

    // We need to use a getter here because I want the text to update
    // when score is changed
    public int getScore ()
    {
        return _score;
    }
}
