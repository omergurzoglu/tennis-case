
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
    
    public int coinScore;
    public int highScore;
    private Camera _camera;

    private void Awake() => _camera=Camera.main;

    private void Start()
    {
        highScoreText.text = highScore.ToString();
        coinText.text = coinScore.ToString();
    }

    private IEnumerator IncrementScoreRoutine()
    {
        var coinPos = _camera.WorldToScreenPoint(ballTransform.position);
        var newCoin=CoinSpritePool.Instance.GetPooledSprite();
        newCoin.SetActive(true);
        if (newCoin!=null)
        {
            newCoin.transform.position = coinPos;
            newCoin.transform.DOMove(uICoinSpritePos.position, 1.5f).SetEase(Ease.InQuart);
        }
        yield return new WaitForSeconds(1.5f);
        HighScorePlus();
        CoinScorePlus(1);
        ShakeScaleOfSprite(uICoinSpritePos);
        DisableSprite(newCoin);
    }

    public void ScoreCoroutine()
    {
        StartCoroutine(IncrementScoreRoutine());
    }

    private TweenCallback ShakeScaleOfSprite(Transform obj)
    {
        obj.DORewind();
        obj.DOPunchScale (new Vector3 (1, 1, 1), .25f);
        return null;
    }

    private void DisableSprite(GameObject obj) => obj.SetActive(false);

    private void HighScorePlus()
    {
        highScore++;
        highScoreText.text = highScore.ToString();
    }

    private void CoinScorePlus(int amount)
    {
        coinScore+=amount;
        coinText.text = coinScore.ToString();

    }
    
    
    
}