using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NodeEffect
{
    public abstract string flavorText { get; }
    public abstract void Effect(ref PlayerController player);
}
