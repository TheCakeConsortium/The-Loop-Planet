using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_ReduceStats : NodeEffect
{
    override
    public string flavorText
    {
        get { return "The day is tiring, and I didn't eat anything...\nHunger(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.hunger--;
    }
}
