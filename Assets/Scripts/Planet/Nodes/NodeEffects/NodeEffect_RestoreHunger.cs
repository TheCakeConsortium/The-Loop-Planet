﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEffect_RestoreHunger : NodeEffect
{
    override
    public string flavorText
    {
        get { return "I found some food and had a nice meal. Yay!\nHunger(10) restored"; }
    }

    override
    public void Effect(ref PlayerController player)
    {
        player.hunger = 10;
    }
}
