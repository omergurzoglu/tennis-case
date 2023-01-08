
using UnityEngine;

public class PlayerDetectLaser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Laser>(out _))
        {
            ScoreManager.Instance.ScoreCoroutine();
        }
    }
}
