using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameMaster GM;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;

    public int hunger { get; set; }
    public int thermalWelfare { get; set; }
    public int batteryPower { get; set; }
    public int numOfBridges { get; set; }

    public int currentNodeIndex { get; private set; }

    [SerializeField] PlanetRingWorld planet;

    // Start is called before the first frame update
    void Start()
    {
        DisplaceToTopOfPlanet(new Vector3(0, 0.05f, 0));
        hunger = 10;
        thermalWelfare = 10;
        batteryPower = 10;
        numOfBridges = 1;
        currentNodeIndex = 0;
    }

    public void UpdateNewNodeEffect()
    {
        GetCurrentPlanetNode().TriggerEffect();

        if(hunger <= 0 || thermalWelfare <= 0 || batteryPower <= 0)
        {
            GM.LoseGame();
        }
    }

    private void DisplaceToTopOfPlanet(Vector3 offset)
    {
        transform.position = new Vector3(0, planet.length, 0) + GM.planet.containerForBoth.transform.position + offset;
    }

    public PlanetNode GetCurrentPlanetNode()
    {
        return planet.listOfNodes[currentNodeIndex];
    }

    public void ChangePlanetNode(int num)
    {
        if (Mathf.Abs(num) > planet.numOfNodes)
        {
            Debug.Log("delta of planet node is too much");
            return;
        }

        currentNodeIndex += num;

        if(currentNodeIndex < 0)
        {
            int actualNode = planet.numOfNodes + currentNodeIndex;
            currentNodeIndex = actualNode;
        }
        else if(currentNodeIndex >= planet.numOfNodes)
        {
            int actualNode = currentNodeIndex - planet.numOfNodes;
            currentNodeIndex = actualNode;
        }
    }

    public void SetPlayerAnim(bool isWalking, bool isFlip)
    {
        anim.SetBool("isWalking", isWalking);
        sprite.flipX = isFlip;
    }
}
