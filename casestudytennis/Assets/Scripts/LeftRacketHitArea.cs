using System;
using UnityEngine;

public class LeftRacketHitArea : RacketHitAreaBase
{
    [SerializeField]private Transform leftTargetAnchor;
    [SerializeField] private Racket leftRacket;
    private void Awake()
    {
        Racket = leftRacket;
        TargetAnchor = leftTargetAnchor;
    }
    
}