﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNode_Sea : PlanetNode
{
    private new void Start()
    {
        base.Start();
        InitEffects();
    }

    private void InitEffects()
    {
        effects.Add(new NodeEffect_ReduceStats());
        effects.Add(new NodeEffect_ColdByWater());
        effects.Add(new NodeEffect_BatteryDrain());
    }
}
