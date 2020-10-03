using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_ReduceStats : NodeEffect
{
    override
    public void Effect(ref PlayerController player)
    {
        player.hunger--;
    }
}
