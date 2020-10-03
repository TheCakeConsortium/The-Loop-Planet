using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameMaster GM;

    public int hunger { get; set; }
    public int warmth { get; set; }
    public int numOfBridges { get; set; }

    public int currentNodeIndex = 0;

    [SerializeField] PlanetRingWorld planet;

    // Start is called before the first frame update
    void Start()
    {
        DisplaceToTopOfPlanet();
        hunger = 10;
        numOfBridges = 1;
    }

    public void UpdateNewNodeEffect()
    {
        GetCurrentPlanetNode().TriggerEffect();
        Debug.Log("hunger: " + hunger + "   warmth: " + warmth + "  numofbridges: " + numOfBridges);

        if(hunger <= 0)
        {
            GM.LoseGame();
        }
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
