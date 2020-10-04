using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNode_Normal : PlanetNode
{
    private new void Start()
    {
        base.Start();
        InitEffects();
        flavorText = "This is just a normal looking place...huh";
    }

    private void InitEffects()
    {
        effects.Add(new NodeEffect_ReduceStats());
    }
}
