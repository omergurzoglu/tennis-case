
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out var player))
        {
            LevelManager.Instance.GameOver();
        }
    }
    
}