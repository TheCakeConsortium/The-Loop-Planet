using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetNode : MonoBehaviour
{
    public int index { get; set; }
    List<int> listOfEntities;
    List<int> listOfEvents;

    int parameter;

    Sprite picture;

    [SerializeField] Button button;
    [SerializeField] UIMaster uiRef;

    [SerializeField] List<NodeEffect> effect;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnClickFunction);
    }

    void OnClickFunction()
    {
        uiRef.ChangeSelection(this);
        Debug.Log("node number " + index + " at " + transform.position + " is clicked!");
    }

    public void TriggerEffect()
    {
        foreach(var ef in effect)
        {
            ef.Effect();
        }
    }
}
