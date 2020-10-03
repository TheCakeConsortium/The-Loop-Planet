using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The planet will contain a list of planet nodes and planet links, forming a graph.
public class PlanetMain : MonoBehaviour
{
    public List<PlanetNode> listOfNodes;
    public List<PlanetLink> listOfLinks;

    //Must have the node and link components in the game objects!
    public GameObject typeOfNode;
    public GameObject typeOfLink;

    protected int numberOfNodes;

    protected void GenerateInitPlanet(GraphGenerator generator, float scale)
    {
        GraphGenerator.GraphData graphData = generator.Generate(numberOfNodes, scale, Vector3.zero);
        for(int i=0; i<graphData.nodes.Count; i++)
        {
            GameObject obj = Instantiate(typeOfNode, graphData.nodes[i], Quaternion.identity);
            listOfNodes.Add(obj.GetComponent<PlanetNode>());
        }

        for(int i=0; i<graphData.links.Count; i+=2)
        {
            //Will definetly have no direction links because i said so.
            if(!graphData.isLinksDirectional)
            {
                GameObject obj = Instantiate(typeOfLink, Vector3.zero, Quaternion.identity);
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
}
