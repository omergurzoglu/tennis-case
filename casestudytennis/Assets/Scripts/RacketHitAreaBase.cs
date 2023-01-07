
using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class RacketHitAreaBase : MonoBehaviour,IHitBall
{
    protected Transform TargetAnchor;
    
    public static event Action<Vector3> IncomingBallPositionBroadcast;
    
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
        var randomTargetPos = targetDirection + new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-10f, 10f));
        //OnIncomingBallPositionBroadcast(randomTargetPos);
        ball.GetComponent<Rigidbody>().velocity = randomTargetPos* racketHitForce + new Vector3(0, 6, 0);
    }


    private static void OnIncomingBallPositionBroadcast(Vector3 pos)
    {
        IncomingBallPositionBroadcast?.Invoke(pos);
    }
}

public interface IHitBall
{
    void HitBall(Transform target,Vector3 hitPos,Ball ball);
    
}