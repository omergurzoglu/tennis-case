
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class RacketBase : MonoBehaviour,IHitBall
{
    protected Transform TargetAnchor;
    
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
        var randomTargetPos = targetDirection + new Vector3(Random.Range(0f, 3f), 0, Random.Range(0f, 8f));
        ball.GetComponent<Rigidbody>().velocity = randomTargetPos* racketHitForce + new Vector3(0, 6, 0);
    }
}

public interface IHitBall
{
    void HitBall(Transform target,Vector3 hitPos,Ball ball);
    
}