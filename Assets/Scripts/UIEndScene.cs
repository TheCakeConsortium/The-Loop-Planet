using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEndScene : MonoBehaviour
{
    [SerializeField] Button button_goBack;
    // Start is called before the first frame update
    void Start()
    {
        button_goBack.onClick.AddListener(GoBack);
    }

    void GoBack()
    {
        SceneManager.LoadScene(1);
    }
}
