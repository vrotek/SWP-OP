using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : Zustand {

    public override void GameAction(GameManager gameManager)
    {
        
        
        gameManager.setState(new StartState());
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

  
}
