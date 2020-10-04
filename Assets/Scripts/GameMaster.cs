using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Should use singleton pattern, but i don't want to risk it with monobehaviour
//And i'm too anxious to code properly
//If there is a need to access, create a serializefield and connect to the object with this class
//Or find it
public class GameMaster : MonoBehaviour
{
    public PlayerController player;
    public UIMaster ui;
    public PlanetMain planet;

    public int numberOfDays = 0;
    public int numberOfDays_limit = 3;

    public void AddDaysPassed(int daysPassed)
    {
        numberOfDays += daysPassed;
        if(numberOfDays >= numberOfDays_limit)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        Debug.Log("You win lol");
        GoToWinScene();
    }

    public void LoseGame()
    {
        Debug.Log("You lose lol");
        GoToLoseScene();
    }

    private void GoToWinScene()
    {
        SceneManager.LoadScene(2);
    }

    private void GoToLoseScene()
    {
        SceneManager.LoadScene(3);
    }
}
