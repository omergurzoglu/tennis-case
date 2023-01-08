
using System.Collections;
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
        StartCoroutine(GameOverCoroutine());
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

    private IEnumerator GameOverCoroutine()
    {
        gameOverPanel.gameObject.SetActive(true);
        for (float time = 1; time >= 0; time-=0.1f)
        {
            Time.timeScale =time;
            yield return new WaitForSeconds(0.05f);
        }
        Time.timeScale = 0;
    }


}