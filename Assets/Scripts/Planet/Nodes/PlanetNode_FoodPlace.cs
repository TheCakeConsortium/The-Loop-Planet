using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNode_FoodPlace : PlanetNode
{
    private new void Start()
    {
        base.Start();
        InitEffects();
    }

    private void InitEffects()
    {
        effects.Add(new NodeEffect_RestoreHunger());
    }
}
