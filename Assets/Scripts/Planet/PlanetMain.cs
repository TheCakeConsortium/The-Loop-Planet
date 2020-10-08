using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The planet will contain a list of planet nodes and planet links, forming a graph.
public class PlanetMain : MonoBehaviour
{
    [SerializeField] GameMaster GM;

    public List<PlanetNode> listOfNodes { get; set; }
    public List<PlanetLink> listOfLinks { get; set; }

    //Must have the node and link components in the game objects!
    public List<GameObject> typeOfNode;
    public GameObject typeOfLink;

    public GameObject containerForBoth;
    public GameObject containerForNodes;
    public GameObject containerForLinks;

    public bool isPlanetRotating = false;

    //Add node based on the indexing of the typeOfNode, will determine what kind of node spawn at each index.
    //Insert the appropriate list of integers to spawn the appropriate node types for each node.
    protected void GenerateInitPlanet(GraphGenerator generator, List<int> nodeTypes, int numberOfNodes, float scale)
    {
        listOfNodes = new List<PlanetNode>();
        listOfLinks = new List<PlanetLink>();

        GraphGenerator.GraphData graphData = generator.Generate(numberOfNodes, scale, containerForBoth.transform.position);
        for(int i=0; i<graphData.nodes.Count; i++)
        {
            if (i > nodeTypes.Count - 1)
                break;
            GameObject obj = Instantiate(typeOfNode[nodeTypes[i]], graphData.nodes[i], graphData.nodes_rot[i], containerForNodes.transform);
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

    public void MakeLink(int fromNode, int toNode)
    {
        GameObject obj = Instantiate(typeOfLink, Vector3.zero, Quaternion.identity, containerForLinks.transform);
        PlanetLink link = obj.GetComponent<PlanetLink>();
        link.nodePrev = listOfNodes[fromNode];
        link.nodeNext = listOfNodes[toNode];
        link.PlaceLinkAtNodes();
        listOfLinks.Add(link);
    }

    public PlanetLink CheckForLinks(int index)
    {
        //Start from the number of nodes, assume the first few links are initial links.
        //Only check for additional links
        for(int i=listOfNodes.Count; i<listOfLinks.Count; i++)
        {
            if(listOfLinks[i].nodePrev.index == index || listOfLinks[i].nodeNext.index == index)
            {
                return listOfLinks[i];
            }
        }
        return null;
    }

    public void BeginRotatePlanet(float angle)
    {
        StartCoroutine(RotatePlanet(angle, 0.7f));
    }

    public void BeginRotatePlanet(int startingIndex, int stoppingIndex)
    {
        float angle = (360f / listOfNodes.Count) * (stoppingIndex - startingIndex) * -1;
        StartCoroutine(RotatePlanet(angle, 0.7f));
    }

    private IEnumerator RotatePlanet(float deltaAngle, float speed)
    {
        isPlanetRotating = true;
        if (speed > 1 || speed <= 0)
            speed = 1;

        float angle = 0;
        float angleChange = speed * deltaAngle;
        GM.player.SetPlayerAnim(true, (deltaAngle < 0 ? false : true));

        while (Mathf.Abs(angle) < Mathf.Abs(deltaAngle))
        {
            containerForBoth.transform.Rotate(Vector3.forward, angleChange * Time.deltaTime);
            angle += angleChange * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        GM.player.SetPlayerAnim(false, (deltaAngle < 0 ? false : true));
        containerForBoth.transform.Rotate(Vector3.forward, deltaAngle - angle);
        isPlanetRotating = false;
    }
}
