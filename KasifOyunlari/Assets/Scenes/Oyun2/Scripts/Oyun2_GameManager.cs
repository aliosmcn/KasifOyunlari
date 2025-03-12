using System;
using Scenes.Oyun2.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Oyun2_GameManager : MonoBehaviour
{
    private int TotalScore;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject finishText;

    private void OnEnable()
    {
        Oyun2_GeneralEvents.OnGameEnded += GameEnded;
        Oyun2_GeneralEvents.OnScoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        Oyun2_GeneralEvents.OnScoreChanged -= ChangeScore;
        Oyun2_GeneralEvents.OnGameEnded -= GameEnded;
    }

    private void ChangeScore(int score)
    {
        TotalScore += score;
        scoreText.text = "Skor: " + TotalScore;
    }
    
    private void GameEnded()
    {
        
    }
}
