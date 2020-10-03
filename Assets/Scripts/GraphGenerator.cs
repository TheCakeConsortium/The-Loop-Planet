using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GraphGenerator
{
    public struct GraphData
    {
        public bool isLinksDirectional;
        public List<Vector3> nodes;
        //links are a multiple of 2, every 2 integers are the linkage between 2 nodes of that index
        //links may be directional, it would go from the 1st to 2nd, 3rd to 4th, and so on.
        //For this ludum dare game jam, assume all links are bidirectional (no direction, just a line)
        public List<int> links; 
    }
    public abstract GraphData Generate(int numberOfNodes, float avgDistance, Vector3 offset);
}
