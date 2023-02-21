using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int _scoreValue = 0;
    public int _scoreMax = 0;
    public Text scoreText;
    public KidSpawner KS;

    
    private void OnEnable()
    {
        KidController.OnUpdateScore += UpdateScoreValue;
    }
    
    private void OnDisable()
    {
        KidController.OnUpdateScore -= UpdateScoreValue;
    }

    public void UpdateScoreValue()
    {
        _scoreValue++;
        KS.killedkid++;
        scoreText.text = _scoreValue + "/100";
        if (_scoreValue >= _scoreMax)
        {
            Debug.Log("You win!!!!!!");
        }

    }
}
