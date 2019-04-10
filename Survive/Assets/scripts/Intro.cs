using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {
     GameManager gameManager = GameManager.getInstance();

    public void Enter()
    {

        GameManager gameManager = GameManager.getInstance();
        gameManager.getState().ChangeScene();
    }

    private void Awake()
    {
        StartState startState = new StartState();
        startState.GameAction();
        

    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
        
    }





