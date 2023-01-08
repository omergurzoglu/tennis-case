
using UnityEngine;

public class RightRacketHitArea : RacketHitAreaBase
{

    [SerializeField] private Transform rightTargetAnchor;
    [SerializeField] private Racket rightRacket;

    private void Awake()
    {
        Racket = rightRacket;
        TargetAnchor = rightTargetAnchor;
    }
}