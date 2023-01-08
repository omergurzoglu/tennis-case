

using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _ballRigidbody;

    private void Awake()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        BallInitialVelocity();
    }

    private void BallInitialVelocity()
    {
        _ballRigidbody.velocity = new Vector3(-15, 5, 0);

    }
    
}
