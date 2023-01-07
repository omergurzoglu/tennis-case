using System;
using UnityEngine;

public class RightRacketHitArea : RacketHitAreaBase
{

    [SerializeField] private Transform rightTargetAnchor;

    private void Awake()
    {
        TargetAnchor = rightTargetAnchor;
    }
}