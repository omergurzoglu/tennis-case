
using DG.Tweening;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Vector3 _thisPos;

    private void Awake()
    {
        _thisPos = transform.position;
    }

    private void OnEnable() => RacketHitAreaBase.IncomingBallPositionBroadcast += MoveRacketToPosition;

    private void OnDisable() => RacketHitAreaBase.IncomingBallPositionBroadcast -= MoveRacketToPosition;

    private void MoveRacketToPosition(Vector3 desiredPos,Racket racket)
    {
        if (racket == this)
        {
            transform.DOMove(new Vector3(_thisPos.x, desiredPos.y, desiredPos.z), 0.1f).SetEase(Ease.InSine)
                .OnComplete((() => transform.DOShakeScale(0.3f, 1f)));
            transform.DOShakeRotation(0.2f);
        }
    }
}