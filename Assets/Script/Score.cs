using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int _scoreValue = 0;
    [SerializeField] private int _scoreMax = 0;
    [SerializeField] private Text scoreText;
    [SerializeField] private Image _HealthBar;
    [SerializeField] private PlayerDatas _playerDatas;
    public Player player;
    
    private void OnEnable()
    {
        KidController.OnUpdateScore += UpdateScoreValue;
        Player.OnUpdateHealth += UpdateHealthBar;
    }
    
    private void OnDisable()
    {
        KidController.OnUpdateScore -= UpdateScoreValue;
        Player.OnUpdateHealth -= UpdateHealthBar;

    }

    public void UpdateScoreValue()
    {
        _scoreValue++;
        scoreText.text = _scoreValue + "/100";
        if (_scoreValue >= _scoreMax)
        {
            Debug.Log("You win!!!!!!");
        }
    }
    
    private void UpdateHealthBar()
    {
        _HealthBar.fillAmount = _playerDatas.LifePoint / _playerDatas.MaxLifePoint;
    }
}
