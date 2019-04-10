using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : Zustand {
    GameManager gameManager = GameManager.getInstance();

    public override void GameAction()
    {

        
        gameManager.setState(new LoseState());
        
    }

    public override void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
    
}
