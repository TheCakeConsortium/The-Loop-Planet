using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_RestoreHunger_Partial : NodeEffect
{
    override
    public string flavorText
    {
        get { return "I found a little food...this will keep starvation at bay.\nHunger(+5) restored"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.hunger += 5;
        if (player.hunger > 10)
            player.hunger = 10;
    }
}
