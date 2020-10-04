using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_Hot : NodeEffect
{
    override
    public string flavorText
    {
        get { return "The weather is too hot!! I can feel my skin blistering!.\nThermal Welfare(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.thermalWelfare -= 1;
    }
}
