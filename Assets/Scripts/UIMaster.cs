using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//This code is probably gonna be very VERY messy, haha
public class UIMaster : MonoBehaviour
{
    [SerializeField] GameMaster GM;

    PlanetNode currentSelectedNode;
    [SerializeField] UIMasterNodeCursor currentSelectedCursor;

    [SerializeField] Button button_moveL;
    [SerializeField] Button button_moveR;
    [SerializeField] Button button_stay;
    [SerializeField] Button buttion_buildLink;

    List<string> messageList;
    [SerializeField] TextMeshProUGUI messageList_text;

    // Start is called before the first frame update
    void Start()
    {
        button_moveL.onClick.AddListener(OnClickLeftFunction);
        button_moveR.onClick.AddListener(OnClickRightFunction);
    }

    void OnClickLeftFunction()
    {
        GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, GM.player.currentNodeIndex + 1);
        GM.player.currentNodeIndex++;
        Debug.Log(GM.player.GetCurrentPlanetNode().index);
        GM.player.UpdateNewNodeEffect();
        GM.AddDaysPassed(1);
    }

    void OnClickRightFunction()
    {
        GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, GM.player.currentNodeIndex - 1);
        GM.player.currentNodeIndex--;
        Debug.Log(GM.player.GetCurrentPlanetNode().index);
        GM.player.UpdateNewNodeEffect();
        GM.AddDaysPassed(1);
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
