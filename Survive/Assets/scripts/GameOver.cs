using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

    [SerializeField] private Slider people;
    [SerializeField] private Slider defense;
    [SerializeField] private Slider faith;
    [SerializeField] private Slider food;

    

    

    

    GameManager gameManager = GameManager.getInstance();

    

    // Update is called once per frame
    private GameOver() { }

    

    


    void Update () {
        if(people.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
           
            Endscreen.ds = "people";
        }
        else if (defense.value <= 0 )
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "defense";
        }
        else if (faith.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "faith";
        }
        else if (food.value <= 0)
        {
            LoseState lose = new LoseState();
            lose.GameAction();
            GameManager gameManager = GameManager.getInstance();
            gameManager.getState().ChangeScene();
            
            Endscreen.ds = "food";
        }
	}
}
