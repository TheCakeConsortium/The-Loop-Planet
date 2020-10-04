using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_Cold : NodeEffect
{
    override
    public string flavorText
    {
        get { return "I'm freezing cold!! I don't feel so good.\nThermal Welfare(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.thermalWelfare -= 1;
    }
}
