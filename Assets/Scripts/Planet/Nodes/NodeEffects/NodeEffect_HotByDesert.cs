using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_HotByDesert : NodeEffect
{
    override
    public string flavorText
    {
        get { return "The weather is quite hot. I could use a drink or two.\nThermal Welfare(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.thermalWelfare -= 1;
    }
}
