
using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Transform gameOverPanel;
    [SerializeField] private Transform startPanel;
    [SerializeField] private float increaseDifficultyAfterTime;
    [SerializeField] private float difficultyForce;
    
    public static event Action<float,float> IncreaseDifficulty;
    private bool _gamePaused;
    
    private void Awake()
    {
        _gamePaused = true;
        Time.timeScale = 0;
        startPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
    }

    public bool IsGamePaused() => _gamePaused;

    public void TapToStart() => StartCoroutine(StartDelay());

    public void GameOver() => StartCoroutine(GameOverCoroutine());

    public void RestartGame()
    {
        gameOverPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame() => Application.Quit();

    private IEnumerator GameOverCoroutine()
    {
        foreach (var sprite in CoinSpritePool.Instance._moneySprite)
        {
            if (sprite.activeInHierarchy)
            {
                sprite.SetActive(false);
            }
        }

        gameOverPanel.gameObject.SetActive(true);
        for (float time = 1; time >= 0; time-=0.1f)
        {
            Time.timeScale =time;
            yield return new WaitForSeconds(0.05f);
        }
        Time.timeScale = 0;
    }

    private IEnumerator StartDelay()
    {
        startPanel.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(0.4f);
        _gamePaused = false;
        Time.timeScale = 1;
        OnIncreaseDifficulty(increaseDifficultyAfterTime,difficultyForce);
    }
    
    private void OnIncreaseDifficulty(float time,float force) => IncreaseDifficulty?.Invoke(time,force);
}