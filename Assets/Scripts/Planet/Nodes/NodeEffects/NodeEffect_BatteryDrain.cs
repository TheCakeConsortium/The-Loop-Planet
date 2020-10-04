using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_BatteryDrain : NodeEffect
{
    override
    public string flavorText
    {
        get { return "My suit's battery is draining...\nBattery Power(-1)"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.batteryPower -= 1;
    }
}
