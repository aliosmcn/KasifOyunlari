using System;
using Scenes.Oyun2.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Oyun2_GameManager : MonoBehaviour
{
    private int TotalScore;
    
    [Header("UI")]
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject finishText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject XButton;
    [SerializeField] private TextMeshProUGUI pauseText;

    
    private void OnEnable()
    {
        Oyun2_GeneralEvents.OnGameFinish += GameEnded;
        Oyun2_GeneralEvents.OnGameOver += GameOver;
        Oyun2_GeneralEvents.OnScoreChanged += ChangeScore;
    }

    private void OnDisable()
    {
        Oyun2_GeneralEvents.OnScoreChanged -= ChangeScore;
        Oyun2_GeneralEvents.OnGameFinish -= GameEnded;
        Oyun2_GeneralEvents.OnGameOver -= GameOver;
    }

    private void Start()
    {
        Time.timeScale = 1;
        XButton.SetActive(true);
    }

    private void ChangeScore(int score)
    {
        TotalScore += score;
        scoreText.text = "Skor: " + TotalScore;
        if (TotalScore == 9) GameEnded();
    }
    
    private void GameEnded()
    {
        pauseText.text = "Tebrikler, kazandınız.";
        XButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    private void GameOver()
    {
        pauseText.text = "Kaybettiniz.";
        XButton.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void PausePanel(bool state)
    {
        pauseText.text = "Devam etmek için X";
        pausePanel.SetActive(state);
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void AnaMenu()
    {
        Time.timeScale = 1;
        
        pausePanel.SetActive(false);
        XButton.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
