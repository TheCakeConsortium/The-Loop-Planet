using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_ReduceStats : NodeEffect
{
    override
    public string flavorText
    {
        get { return "You are getting hungrier!"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.hunger--;
    }
}
