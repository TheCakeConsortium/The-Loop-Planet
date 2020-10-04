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

        nodeTypes.Add(1);
        nodeTypes.Add(1);

        nodeTypes.Add(2);
        nodeTypes.Add(2);
        nodeTypes.Add(2);

        nodeTypes.Add(2);

        nodeTypes.Add(3);
        nodeTypes.Add(3);
        nodeTypes.Add(3);

        nodeTypes.Add(4);
        nodeTypes.Add(4);
        nodeTypes.Add(4);

        nodeTypes.Add(5);

        nodeTypes.Add(5);
        nodeTypes.Add(5);
        nodeTypes.Add(5);
        nodeTypes.Add(5);

        nodeTypes.Add(6);
        nodeTypes.Add(6);

        nodeTypes.Add(1);


        //Use the circular loop generator
        GraphGeneratorCircularLoop generator = new GraphGeneratorCircularLoop();
        GenerateInitPlanet(generator, nodeTypes, numOfNodes, length);
    }
}
