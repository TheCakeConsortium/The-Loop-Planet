using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This code is probably gonna be very VERY messy, haha
public class UIMaster : MonoBehaviour
{
    PlanetNode currentSelectedNode;
    [SerializeField] UIMasterNodeCursor currentSelectedCursor;

    [SerializeField] Button button_moveL;
    [SerializeField] Button button_moveR;
    [SerializeField] Button buttion_buildLink;

    List<string> messageList;
    [SerializeField] TextMeshProUGUI messageList_text;

    [SerializeField] PlanetMain planet;
    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        button_moveL.onClick.AddListener(OnClickLeftFunction);
        button_moveR.onClick.AddListener(OnClickRightFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickLeftFunction()
    {
        planet.BeginRotatePlanet(player.currentNodeIndex, player.currentNodeIndex + 1);
        player.currentNodeIndex++;
        Debug.Log(player.GetCurrentPlanetNode().index);
    }

    void OnClickRightFunction()
    {
        planet.BeginRotatePlanet(player.currentNodeIndex, player.currentNodeIndex - 1);
        player.currentNodeIndex--;
        Debug.Log(player.GetCurrentPlanetNode().index);
    }

    public void ChangeSelection(PlanetNode node)
    {
        currentSelectedNode = node;
        UpdateSelectionUI();
    }

    private void UpdateSelectionUI()
    {
        StartCoroutine(MoveSelectionCursor());
    }

    private IEnumerator MoveSelectionCursor()
    {
        currentSelectedCursor.isTransiting = true;
        Vector3 newPos = currentSelectedNode.transform.position;
        currentSelectedCursor.transform.position = newPos;

        currentSelectedCursor.targetNode = currentSelectedNode;
        currentSelectedCursor.isTransiting = false;
        yield return null;
    }
}
