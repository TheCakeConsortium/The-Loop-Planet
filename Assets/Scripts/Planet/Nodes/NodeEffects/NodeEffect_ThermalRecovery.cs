using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_ThermalRecovery : NodeEffect
{
    override
    public string flavorText
    {
        get { return "The environment is rather pleasant. I'm feeling pretty good.\nThermal Welfare(10) restored"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.thermalWelfare = 10;
    }
}
