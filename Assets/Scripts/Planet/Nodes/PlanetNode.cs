using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetNode : MonoBehaviour
{
    [SerializeField] Button button;

    GameMaster GM;
    public int index { get; set; }
    public List<NodeEffect> effects = new List<NodeEffect>();

    public string flavorText;
    public Sprite flavorImage;

    public string additionalText;

    // Start is called before the first frame update
    protected void Start()
    {
        button.onClick.AddListener(OnClickFunction);
        GM = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void OnClickFunction()
    {
        GM.ui.ChangeSelection(this);
        Debug.Log("node number " + index + " at " + transform.position + " is clicked!");
    }

    public void TriggerEffect()
    {
        foreach(var ef in effects)
        {
            ef.Effect(ref GM.player);
        }
    }

    public string GetFlavorText()
    {
        string finalText = flavorText + "\n";
        foreach(var ef in effects)
        {
            finalText += (ef.flavorText + "\n");
        }
        return finalText;
    }
}
