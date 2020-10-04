using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

//This code is very VERY bad and very messy, haha
public class UIMaster : MonoBehaviour
{
    [SerializeField] GameMaster GM;

    bool isCursorActive = true;
    bool isSelectionDone = true;
    PlanetNode currentSelectedNode;
    PlanetNode selectedNode1;
    PlanetNode selectedNode2;
    [SerializeField] UIMasterNodeCursor currentSelectedCursor;
    private event Action<PlanetNode> OnSelectionChange;
    private event Action<int> OnNodeChange;

    [SerializeField] Button button_moveL;
    [SerializeField] Button button_moveR;
    [SerializeField] Button button_stay;
    [SerializeField] Button button_buildLink;
    [SerializeField] Button button_moveOnLink;
    private PlanetLink linkStandingOn;
    [SerializeField] Button button_cancelBuildLink;
    bool isLinkBuildingCancel = false;

    int messageLimit = 10;
    Queue<string> messageList = new Queue<string>();
    [SerializeField] TextMeshProUGUI flavorText_text;
    [SerializeField] Image flavorText_image;
    private event Action OnFlavorTextUpdate;

    [SerializeField] GameObject message_extraInfo_obj;
    [SerializeField] TextMeshProUGUI message_extraInfo;

    [SerializeField] TextMeshProUGUI message_playerStats;

    // Start is called before the first frame update
    void Start()
    {
        button_moveL.onClick.AddListener(OnClickLeftFunction);
        button_moveR.onClick.AddListener(OnClickRightFunction);
        button_buildLink.onClick.AddListener(OnClickMakeLinkFunction);
        button_moveOnLink.onClick.AddListener(OnClickMoveOnLinkFunction);
        button_cancelBuildLink.onClick.AddListener(CancelBuildLink);
        OnNodeChange += CheckForLinkExistence;
        OnFlavorTextUpdate += UpdateFlavorText;
        UpdatePlayerStatsUI();
    }

    private void Update()
    {

    }

    void UpdatePlayerStatsUI()
    {
        message_playerStats.text =
            "Hunger: " + GM.player.hunger + "\n" +
            "Thermal: " + GM.player.thermalWelfare + "\n" +
            "Battery: " + GM.player.batteryPower + "\n" +
            "Links left: " + GM.player.numOfBridges + "\n\n" +
            "Days left: " + (GM.numberOfDays_limit - GM.numberOfDays).ToString()
            ;
    }

    public void PushMessage(string msg)
    {
        messageList.Enqueue(msg);

        if (messageList.Count > messageLimit)
            messageList.Dequeue();

        if (OnFlavorTextUpdate != null)
            OnFlavorTextUpdate.Invoke();
    }

    public void PushMessage(string msg, Sprite img)
    {
        messageList.Enqueue(msg);

        if (messageList.Count > messageLimit)
            messageList.Dequeue();

        if (OnFlavorTextUpdate != null)
            OnFlavorTextUpdate.Invoke();

        UpdateFlavorImage(img);
    }

    private void UpdateFlavorText()
    {
        flavorText_text.text = "";

        for(int i=messageList.Count-1; i>-1; i--)
        {
            flavorText_text.text += (messageList.ElementAt(i) + "\n\n");
        }
    }

    private void UpdateFlavorImage(Sprite img)
    {
        flavorText_image.sprite = img;
    }

    void CheckForLinkExistence(int index)
    {
        PlanetLink link = GM.planet.CheckForLinks(index);
        if(link != null)
        {
            linkStandingOn = link;
            button_moveOnLink.interactable = true;
        }
        else
        {
            linkStandingOn = null;
            button_moveOnLink.interactable = false;
        }
    }

    void OnClickLeftFunction()
    {
        GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, GM.player.currentNodeIndex + 1);
        GM.player.ChangePlanetNode(1);
        Debug.Log(GM.player.GetCurrentPlanetNode().index);
        GM.player.UpdateNewNodeEffect();
        GM.AddDaysPassed(1);
        StartCoroutine(WaitForPlanetRotation());
    }

    void OnClickRightFunction()
    {
        GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, GM.player.currentNodeIndex - 1);
        GM.player.ChangePlanetNode(-1);
        Debug.Log(GM.player.GetCurrentPlanetNode().index);
        GM.player.UpdateNewNodeEffect();
        GM.AddDaysPassed(1);
        StartCoroutine(WaitForPlanetRotation());
    }

    void OnClickMakeLinkFunction()
    {
        StartCoroutine(WaitForNodeSelection());
    }

    void OnClickMoveOnLinkFunction()
    {
        if(linkStandingOn != null)
        {
            if(linkStandingOn.nodePrev.index == GM.player.currentNodeIndex)
            {
                int delta = linkStandingOn.nodeNext.index - GM.player.currentNodeIndex;
                GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, linkStandingOn.nodeNext.index);
                GM.player.ChangePlanetNode(delta);
                Debug.Log(GM.player.GetCurrentPlanetNode().index);
                GM.player.UpdateNewNodeEffect();
                GM.AddDaysPassed(1);
                StartCoroutine(WaitForPlanetRotation());
            }
            else
            {
                int delta = linkStandingOn.nodePrev.index - GM.player.currentNodeIndex;
                GM.planet.BeginRotatePlanet(GM.player.currentNodeIndex, linkStandingOn.nodePrev.index);
                GM.player.ChangePlanetNode(delta);
                Debug.Log(GM.player.GetCurrentPlanetNode().index);
                GM.player.UpdateNewNodeEffect();
                GM.AddDaysPassed(1);
                StartCoroutine(WaitForPlanetRotation());
            }
            
        }
    }

    void SelectNode(PlanetNode node)
    {
        if (selectedNode1 == null)
        {
            selectedNode1 = node;
        }
        else if (selectedNode2 == null)
        {
            selectedNode2 = node;
            isSelectionDone = true;
        }
    }

    void CancelBuildLink()
    {
        isLinkBuildingCancel = true;
        isSelectionDone = true;
    }

    IEnumerator WaitForNodeSelection()
    {
        if (GM.player.numOfBridges <= 0)
        {
            PushMessage("You have ran out of links!");
            yield break;
        }
            

        isSelectionDone = false;
        ChangeInteractableAllButtons(false);
        button_cancelBuildLink.gameObject.SetActive(true);
        OnSelectionChange += SelectNode;
        ShowExtraInfo("You are now building a link. Click on 2 nodes (the little box buttons) to establish the link.");
        while(!isSelectionDone)
        {
            yield return null;
        }

        if(!isLinkBuildingCancel)
        {
            GM.planet.MakeLink(selectedNode1.index, selectedNode2.index);
            GM.player.numOfBridges--;
            selectedNode1 = null;
            selectedNode2 = null;
        }
        else
        {
            isLinkBuildingCancel = false;
        }

        HideExtraInfo();
        UpdatePlayerStatsUI();
        CheckForLinkExistence(GM.player.currentNodeIndex);
        ChangeInteractableAllButtons(true);
        button_cancelBuildLink.gameObject.SetActive(false);
        OnSelectionChange -= SelectNode;
        isSelectionDone = true;
    }

    IEnumerator WaitForPlanetRotation()
    {
        ChangeInteractableAllButtons(false);
        while (GM.planet.isPlanetRotating)
        {
            yield return null;
        }

        ChangeInteractableAllButtons(true);
        if (OnNodeChange != null)
            OnNodeChange.Invoke(GM.player.currentNodeIndex);

        var node = GM.planet.listOfNodes[GM.player.currentNodeIndex];
        UpdatePlayerStatsUI();
        PushMessage(node.GetFlavorText(), node.flavorImage);
    }

    void ChangeInteractableAllButtons(bool isUnlock)
    {
        button_moveL.interactable = isUnlock;
        button_moveR.interactable = isUnlock;
        button_buildLink.interactable = isUnlock;
        button_moveOnLink.interactable = isUnlock;
    }

    public void ChangeSelection(PlanetNode node)
    {
        if(isCursorActive)
        {
            currentSelectedNode = node;
            if (OnSelectionChange != null)
                OnSelectionChange.Invoke(node);
            UpdateSelectionUI();
        }
    }

    private void UpdateSelectionUI()
    {
        StartCoroutine(MoveSelectionCursor());
    }

    private IEnumerator MoveSelectionCursor()
    {
        currentSelectedCursor.isTransiting = true;
        Vector3 newPos = currentSelectedNode.transform.position;
        Quaternion newRot = currentSelectedNode.transform.rotation;

        currentSelectedCursor.transform.rotation = newRot;

        if(isSelectionDone)
        {
            ShowExtraInfo(currentSelectedNode.additionalText);
        }

        while (Mathf.Abs((newPos - currentSelectedCursor.transform.position).magnitude) > 0.0005)
        {
            currentSelectedCursor.transform.position += (newPos - currentSelectedCursor.transform.position) * 0.1f;
            yield return null;
        }

        currentSelectedCursor.transform.position = newPos;
        currentSelectedCursor.targetNode = currentSelectedNode;
        currentSelectedCursor.isTransiting = false;
        yield return null;
    }

    void ShowExtraInfo(string msg)
    {
        message_extraInfo_obj.SetActive(true);
        message_extraInfo.text = msg;
    }

    void HideExtraInfo()
    {
        message_extraInfo_obj.SetActive(false);
    }
}
