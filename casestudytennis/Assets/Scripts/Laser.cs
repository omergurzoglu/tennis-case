
using DG.Tweening;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out var player))
        {
            player.transform.DOShakeScale(0.3f);
            LevelManager.Instance.GameOver();
        }
    }
    
}