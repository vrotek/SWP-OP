using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private Zustand state;
    void Awake()
    {
        
        if (instance == null)

            
            instance = this;

        
        else if (instance != this)

            
            Destroy(gameObject);

        
        DontDestroyOnLoad(gameObject);
    }

    public GameManager()
    {
        state = null; 
    }

    public void setState(Zustand state)
    {
        this.state = state;
    }

    public Zustand getState()
    {
        return state;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static GameManager getInstance()
    {
        return instance;
    }
}
