using System;
using UnityEngine;

public class LeftRacketHitArea : RacketHitAreaBase
{
    [SerializeField]private Transform leftTargetAnchor;
    private void Awake()
    {
        TargetAnchor = leftTargetAnchor;
    }
    
}