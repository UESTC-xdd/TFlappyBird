using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerScore;
    public Text ScoreText;
    public Text HighScoreText;
    public GameObject GameOverPanel;

    private void Start()
    {
        HighScoreText.text = "High Score: " + SaveMgr.Instance.GetHighestScore();
    }

    [ContextMenu("≤‚ ‘º”∑÷")]
    public void AddScore()
    {
        PlayerScore += 1;
        ScoreText.text = PlayerScore.ToString();
    }

    public void AddScore(int addPoint)
    {
        PlayerScore += addPoint;
        ScoreText.text = PlayerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if(SaveMgr.Instance.GetHighestScore()<PlayerScore)
        {
            HighScoreText.text = "High Score: " + PlayerScore;
            SaveMgr.Instance.SaveScore(PlayerScore);
        }
    }
}
