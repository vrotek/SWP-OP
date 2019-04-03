using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseState : Zustand {


    public override void GameAction(GameManager gameManager)
    {
       
        
        gameManager.setState(new LoseState());
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
