
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class RacketHitAreaBase : MonoBehaviour,IHitBall
{
    protected Transform TargetAnchor;
    protected Racket Racket;
    public static event Action<Vector3,Racket> IncomingBallPositionBroadcast;
    [SerializeField]private float racketHitForce;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<Ball>(out var ball))
        {
            ball.GetComponent<Rigidbody>().velocity.Set(0,0,0);
            HitBall(TargetAnchor,ball.transform.position,ball);
        }
    }
    
    public void HitBall(Transform thisTarget,Vector3 hitPos ,Ball ball)
    {
        var targetDirection = TargetAnchor.position-hitPos;
        var randomTargetPos = targetDirection + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-9f, 9f));
        OnIncomingBallPositionBroadcast(ball.transform.position,Racket);
        ball.GetComponent<Rigidbody>().velocity = randomTargetPos* racketHitForce + new Vector3(0, 6, 0);
    }

    private void OnIncomingBallPositionBroadcast(Vector3 pos,Racket racket)
    {
        IncomingBallPositionBroadcast?.Invoke(pos,racket);
    }
}