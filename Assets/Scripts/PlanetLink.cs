using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This planet link will only connect 2 PlanetNodes, like an edge
//Make it directional...just in case
public class PlanetLink : MonoBehaviour
{
    public PlanetNode nodePrev { get; set; }
    public PlanetNode nodeNext { get; set; }

    //Assume sprite is horizontal, its origin at the left-center and have a length of 1, connect the 2 ends along the x axis
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceLinkAtNodes()
    {
        Vector3 prevPos = nodePrev.transform.position;
        Vector3 nextPos = nodeNext.transform.position;
        Vector3 deltaPos = nextPos - prevPos;
        float angleToRotate = Vector3.SignedAngle(Vector3.right, deltaPos, Vector3.forward);

        transform.position = prevPos;
        transform.Rotate(Vector3.forward, angleToRotate);

        transform.localScale = new Vector3(deltaPos.magnitude, 1, 1);
    }
}
