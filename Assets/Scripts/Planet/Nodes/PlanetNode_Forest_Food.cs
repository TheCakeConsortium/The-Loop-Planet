using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNode_Forest_Food : PlanetNode
{
    private new void Start()
    {
        base.Start();
        InitEffects();
    }

    private void InitEffects()
    {
        effects.Add(new NodeEffect_RestoreHunger());
        effects.Add(new NodeEffect_BatteryDrain());
    }
}
