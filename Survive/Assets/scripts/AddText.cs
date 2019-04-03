﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddText : MonoBehaviour {

    [SerializeField] private Text text;
    [SerializeField] private State currentState;
    [SerializeField] private Slider people;
    [SerializeField] private Slider defense;
    [SerializeField] private Slider faith;
    [SerializeField] private Slider food;
    private State state;

	// Use this for initialization
	void Start () {
        state = currentState;
        text.text = state.getStateStory();
	}

    
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState()
    {
        var nextStates = state.getNextStates();
        for(int i = 0; i < nextStates.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                state = nextStates[i];
                ChangeStates(i);

            }
            

        }
        text.text = state.getStateStory();
    }

    private void ChangeStates(int index)
    {
        Debug.Log(state.getOption(index).faith);
        people.value += state.getOption(index).people;
        defense.value += state.getOption(index).defense;
        faith.value += state.getOption(index).faith;
        food.value += state.getOption(index).food;
    }
}