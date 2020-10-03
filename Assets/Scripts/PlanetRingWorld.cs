using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRingWorld : PlanetMain
{
    private void Start()
    {
        Init();
    }

    void Init()
    {
        numberOfNodes = 30;

        //Use the circular loop generator
        GraphGeneratorCircularLoop generator = new GraphGeneratorCircularLoop();
        GenerateInitPlanet(generator, 5f);
    }
}
