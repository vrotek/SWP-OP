using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

    [SerializeField] private Slider people;
    [SerializeField] private Slider defense;
    [SerializeField] private Slider faith;
    [SerializeField] private Slider food;

    [SerializeField] private GameObject endScreen;

    // Update is called once per frame
    void Update () {
        if(people.value <= 0|| defense.value <= 0|| faith.value <= 0|| food.value <= 0)
        {
            endScreen.gameObject.SetActive(true);
        }
	}
}
