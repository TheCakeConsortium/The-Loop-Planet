using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] List<Canvas> listOfCutscenes;
    int index = 0;
    [SerializeField] Button buttonToProceed;

    // Start is called before the first frame update
    void Start()
    {
        buttonToProceed.onClick.AddListener(GoToNextCutscene);
        UpdateCanvases();
    }

    void UpdateCanvases()
    {
        foreach (var scene in listOfCutscenes)
        {
            scene.gameObject.SetActive(false);
        }
        listOfCutscenes[index].gameObject.SetActive(true);
    }

    void GoToNextCutscene()
    {
        index++;
        if(index <= listOfCutscenes.Count - 1)
        {
            UpdateCanvases();
        }
        else
        {
            StartMainGame();
        }
    }

    void StartMainGame()
    {
        SceneManager.LoadScene(1);
    }
}
