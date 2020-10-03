using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMasterNodeCursor : MonoBehaviour
{
    public bool isTransiting = false;
    public PlanetNode targetNode;

    // Update is called once per frame
    void Update()
    {
        if(!isTransiting && targetNode != null)
        {
            transform.position = targetNode.transform.position;
        }
    }
}
