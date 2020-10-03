using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRingWorld : PlanetMain
{
    public int numOfNodes = 15;
    public float length = 4f;

    private void Start()
    {
        Init();
    }



    void Init()
    {
        List<int> nodeTypes = new List<int>();
        for(int i=0; i<numOfNodes; i++)
        {
            nodeTypes.Add(0);
        }

        //Add a foodplace at index 2, just to test
        nodeTypes[2] = 1;

        //Use the circular loop generator
        GraphGeneratorCircularLoop generator = new GraphGeneratorCircularLoop();
        GenerateInitPlanet(generator, nodeTypes, numOfNodes, length);
    }
}
