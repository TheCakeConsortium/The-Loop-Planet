using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_ColdByWater : NodeEffect
{
    override
    public string flavorText
    {
        get { return "The sea is pretty cold, I can't tolerate it...but not for long.\nThermal Welfare(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.thermalWelfare -= 1;
    }
}
