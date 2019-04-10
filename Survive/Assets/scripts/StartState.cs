using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : Zustand {

    GameManager gameManager = GameManager.getInstance();

    public override void GameAction()
    {
        
        
        gameManager.setState(new StartState());
    }

    public override void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

  
}
