
using DG.Tweening;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out var player))
        {
            player.transform.DOPunchScale(new Vector3(2f,2f,2f), 0.4f);
            LevelManager.Instance.GameOver();
        }
    }
    
}