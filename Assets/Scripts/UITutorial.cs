using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    [SerializeField] Button button_closeTut;
    [SerializeField] GameObject obj_tut;
    // Start is called before the first frame update
    void Start()
    {
        button_closeTut.onClick.AddListener(CloseTutorial);
    }

    void CloseTutorial()
    {
        obj_tut.SetActive(false);
    }
}
