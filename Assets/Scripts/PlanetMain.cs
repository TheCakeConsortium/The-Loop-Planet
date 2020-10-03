using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The planet will contain a list of planet nodes and planet links, forming a graph.
public class PlanetMain : MonoBehaviour
{
    public List<PlanetNode> listOfNodes { get; set; }
    public List<PlanetLink> listOfLinks { get; set; }

    //Must have the node and link components in the game objects!
    public List<GameObject> typeOfNode;
    public GameObject typeOfLink;

    public GameObject containerForBoth;
    public GameObject containerForNodes;
    public GameObject containerForLinks;

    protected void GenerateInitPlanet(GraphGenerator generator, List<int> nodeTypes, int numberOfNodes, float scale)
    {
        listOfNodes = new List<PlanetNode>();
        listOfLinks = new List<PlanetLink>();

        GraphGenerator.GraphData graphData = generator.Generate(numberOfNodes, scale, Vector3.zero);
        for(int i=0; i<graphData.nodes.Count; i++)
        {
            if (i > nodeTypes.Count - 1)
                break;
            GameObject obj = Instantiate(typeOfNode[nodeTypes[i]], graphData.nodes[i], Quaternion.identity, containerForNodes.transform);
            PlanetNode node = obj.GetComponent<PlanetNode>();
            node.index = i;
            listOfNodes.Add(node);
        }

        for(int i=0; i<graphData.links.Count; i+=2)
        {
            //Will definetly have no direction links because i said so.
            if(!graphData.isLinksDirectional)
            {
                GameObject obj = Instantiate(typeOfLink, Vector3.zero, Quaternion.identity, containerForLinks.transform);
                PlanetLink link = obj.GetComponent<PlanetLink>();
                int index1 = graphData.links[i];
                int index2 = graphData.links[i+1];
                link.nodePrev = listOfNodes[index1];
                link.nodeNext = listOfNodes[index2];
                link.PlaceLinkAtNodes();
                listOfLinks.Add(link);
            }
        }
    }

    public void BeginRotatePlanet(float angle)
    {
        StartCoroutine(RotatePlanet(angle, 0.01f));
    }

    public void BeginRotatePlanet(int startingIndex, int stoppingIndex)
    {
        float angle = (360f / listOfNodes.Count) * (stoppingIndex - startingIndex);
        StartCoroutine(RotatePlanet(angle, 0.01f));
    }

    private IEnumerator RotatePlanet(float deltaAngle, float speed)
    {
        if (speed > 1 || speed <= 0)
            speed = 1;

        float angle = 0;
        float angleChange = speed * deltaAngle;

        while (Mathf.Abs(angle) < Mathf.Abs(deltaAngle))
        {
            containerForBoth.transform.Rotate(Vector3.forward, angleChange);
            angle += angleChange;
            yield return null;
        }

        containerForBoth.transform.Rotate(Vector3.forward, deltaAngle - angle);
    }
}
