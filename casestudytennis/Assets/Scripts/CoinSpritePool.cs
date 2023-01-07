using System.Collections.Generic;
using UnityEngine;

public class CoinSpritePool : Singleton<CoinSpritePool>
{
    private readonly List<GameObject> _moneySprite = new();
    private const int SpriteAmount = 10;
    [SerializeField] private GameObject coinSpritePrefab;
    [SerializeField] private Canvas canvas;
    
    private void Start()
    {
        for (var i = 0; i < SpriteAmount; i++)
        {
            var obj = Instantiate(coinSpritePrefab,canvas.transform);
            obj.SetActive(false);
            _moneySprite.Add(obj);
        }
    }
    public GameObject GetPooledSprite()
    {
        for (var i = 0; i < _moneySprite.Count; i++)
        {
            if (!_moneySprite[i].activeInHierarchy)
            {
                return _moneySprite[i];
            }
        }
        return null;
    }
}