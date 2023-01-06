using System;
using UnityEngine;

public class RightRacket : RacketBase
{

    [SerializeField] private Transform rightTargetAnchor;

    private void Awake()
    {
        TargetAnchor = rightTargetAnchor;
    }
}