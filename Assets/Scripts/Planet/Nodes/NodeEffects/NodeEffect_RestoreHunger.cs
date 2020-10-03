using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_RestoreHunger : NodeEffect
{
    override
    public void Effect(ref PlayerController player)
    {
        player.hunger += 5;
    }
}
