using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int hunger = 100;
    int warmth = 100;
    int numOfBridges = 0;

    public int currentNodeIndex = 0;

    [SerializeField] PlanetRingWorld planet;

    // Start is called before the first frame update
    void Start()
    {
        DisplaceToTopOfPlanet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateNewNodeEffect()
    {

    }

    private void DisplaceToTopOfPlanet()
    {
        transform.position = new Vector3(0, planet.length, 0);
    }

    public PlanetNode GetCurrentPlanetNode()
    {
        int acutalIndex = Mathf.Abs(currentNodeIndex % planet.numOfNodes);
        return planet.listOfNodes[acutalIndex];
    }
}
