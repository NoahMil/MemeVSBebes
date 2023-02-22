using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 0;
    [SerializeField] private int _scoreMax = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image _HealthBar;
    [SerializeField] private PlayerDatas _playerDatas;
    public Player player;
    public int stolenCandies;
    
    private void OnEnable()
    {
        KidController.OnUpdateScore += UpdateScoreValue;
     //   Player.OnUpdateHealth += UpdateHealthBar;
    }
    
    private void OnDisable()
    {
        KidController.OnUpdateScore -= UpdateScoreValue;
     //   Player.OnUpdateHealth -= UpdateHealthBar;

    }

    public void UpdateScoreValue()
    {
        _scoreValue++;
        scoreText.text = _scoreValue + "/100";
        if (_scoreValue >= _scoreMax)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
    
    public void Lose()
    {
        if (stolenCandies >= 5)
        {
            Debug.Log("You Lose");
            SceneManager.LoadScene("YouLose");
        }
    }
    
}
    


    //private void UpdateHealthBar()
    //{
    //    _HealthBar.fillAmount = _playerDatas.LifePoint / _playerDatas.MaxLifePoint;
    // }

