
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform uICoinSpritePos;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    
    public int coinScore;
    public int highScore;
    public int currentScore;
    
    private Camera _camera;
    private readonly WaitForSeconds _waitSeconds= new (0.8f);

    private void Awake() => _camera=Camera.main;

    private void Start()
    {
        currentScore = 0;
        coinScore = PlayerPrefs.GetInt("coinScore", 0);
        highScore=PlayerPrefs.GetInt("highScore",0);
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        coinText.text = PlayerPrefs.GetInt("coinScore", 0).ToString();
        
    }

    private IEnumerator IncrementScoreRoutine()
    {
        Vector3 coinPos = _camera.WorldToScreenPoint(ballTransform.position);
        GameObject newCoin=CoinSpritePool.Instance.GetPooledSprite();
        
        newCoin.SetActive(true);
        newCoin.transform.position = coinPos;
        ShakeScaleOfSprite(newCoin.transform);
        newCoin.transform.DOMove(uICoinSpritePos.position, 0.8f).SetEase(Ease.InQuart);
        
        yield return _waitSeconds;
        
        CurrentScorePlus();
        CoinScorePlus(1);
        ShakeScaleOfSprite(uICoinSpritePos);
        DisableSprite(newCoin);
        
        PlayerPrefs.SetInt("coinScore",coinScore);
    }

    public void ScoreCoroutine() => StartCoroutine(IncrementScoreRoutine());

    private TweenCallback ShakeScaleOfSprite(Transform obj)
    {
        obj.DORewind();
        obj.DOPunchScale (new Vector3 (1, 1, 1), .25f);
        return null;
    }

    private void DisableSprite(GameObject obj) => obj.SetActive(false);

    private void CurrentScorePlus()
    {
        currentScore++;
        if (currentScore > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore",currentScore);
            highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        }
        currentScoreText.text = currentScore.ToString();
    }

    private void CoinScorePlus(int amount)
    {
        coinScore+=amount;
        coinText.text = coinScore.ToString();

    }
    
    
    
}