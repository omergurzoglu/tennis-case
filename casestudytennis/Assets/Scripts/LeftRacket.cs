using System;
using UnityEngine;

public class LeftRacket : RacketBase
{
    [SerializeField]private Transform leftTargetAnchor;
    private void Awake()
    {
        TargetAnchor = leftTargetAnchor;
    }
    
}