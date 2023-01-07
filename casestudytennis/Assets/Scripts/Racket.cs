
using DG.Tweening;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Vector3 _thisPos;

    private void Awake()
    {
        _thisPos = transform.position;
    }

    private void OnEnable()
    {
        RacketHitAreaBase.IncomingBallPositionBroadcast += MoveRacketToPosition;
    }

    private void OnDisable()
    {
        RacketHitAreaBase.IncomingBallPositionBroadcast -= MoveRacketToPosition;
    }

    private void MoveRacketToPosition(Vector3 desiresPos)
    {
        transform.DOMove(new Vector3(_thisPos.x, _thisPos.y, desiresPos.z), 0.3f).SetEase(Ease.InSine);
    }
}