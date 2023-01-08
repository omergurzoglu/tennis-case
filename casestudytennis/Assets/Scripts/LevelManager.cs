using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform gameOverPanel;

    private void Awake()
    {
        gameOverPanel.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0.1f;
    }

    public void RestartGame()
    {
        gameOverPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    
}