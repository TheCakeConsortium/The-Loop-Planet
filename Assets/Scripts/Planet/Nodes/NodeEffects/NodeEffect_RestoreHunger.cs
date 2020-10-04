using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_RestoreHunger : NodeEffect
{
    override
    public string flavorText
    {
        get { return "You ate a nice meal and restored your hunger!"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.hunger = 10;
    }
}
