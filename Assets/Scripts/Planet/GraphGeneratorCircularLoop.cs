using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generates circular loop in a 2D plane (x-y plane)
public class GraphGeneratorCircularLoop : GraphGenerator
{
    override
    public GraphData Generate(int numOfNodes, float avgDistance, Vector3 offset)
    {
        if (numOfNodes < 3)
            numOfNodes = 3;

        GraphData output = new GraphData
        {
            nodes = new List<Vector3>(),
            nodes_rot = new List<Quaternion>(),
            links = new List<int>(),

            isLinksDirectional = false
        };

        for (int i=0; i< numOfNodes; i++)
        {
            float angle = 360f * ((float)i / (float)numOfNodes);
            Vector3 pos = offset + (Quaternion.AngleAxis(angle, Vector3.forward) * (new Vector3(0, 1, 0) * avgDistance));
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            output.nodes.Add(pos);
            output.nodes_rot.Add(rot);
            if (i != 0)
            {
                output.links.Add(i - 1);
                output.links.Add(i);
            }
        }

        //Last link to 'cap off' the circle link
        output.links.Add(numOfNodes - 1);
        output.links.Add(0);

        return output;
    }
}
