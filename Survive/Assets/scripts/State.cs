using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {

    [TextArea(14,10)] [SerializeField] private string storyText;
    [SerializeField] private State[] nextStates;

    [SerializeField] private Options[] options;
    



    public string getStateStory()
    {
        return storyText; 
    }

    public State[] getNextStates()
    {

        return nextStates;
    }
    public Options getOption(int i)
    {
        return options[i];
    }

    
}
