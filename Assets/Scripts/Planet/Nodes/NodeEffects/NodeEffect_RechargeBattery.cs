using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_RechargeBattery : NodeEffect
{
    override
    public string flavorText
    {
        get { return "My suit's battery is recharged, nice!\nBattery Power(10) recharged"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.batteryPower = 10;
    }
}
