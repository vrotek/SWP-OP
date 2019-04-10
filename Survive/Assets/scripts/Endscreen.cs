using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Endscreen : MonoBehaviour {

    [SerializeField] private Text people;
    [SerializeField] private Text defense;
    [SerializeField] private Text faith;
    [SerializeField] private Text food;


    public static string ds;

    public void Update()
    {
        if (ds.Equals("people"))
        {
            people.gameObject.SetActive(true);
        }
        else if (ds.Equals("defense"))
        {
            defense.gameObject.SetActive(true);
        }
        else if (ds.Equals("faith"))
        {
            faith.gameObject.SetActive(true);
        }
        else if (ds.Equals("food"))
        {
            food.gameObject.SetActive(true);
        }
    }




}
