using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour {

    private Order people, defense, faith, food, sell;
    public static List<Order> stack = new List<Order>();

    [SerializeField] private Text faithT;
    [SerializeField] private Text peopleT;
    [SerializeField] private Text foodT;
    [SerializeField] private Text defenseT;

    [SerializeField] private Slider faithS;
    [SerializeField] private Slider peopleS;
    [SerializeField] private Slider foodS;
    [SerializeField] private Slider defenseS;

    private void Start()
    {
        people = new PeopleStat();
        defense = new DefenseStat();
        faith = new FaithStat();
        food = new FoodStat();
        sell = new UndoOrder();
    }

    public void Buy()
    {
        Debug.Log("execute buy");
        Debug.Log(people.getGain());
        Debug.Log(defense.getGain());
        Debug.Log(faith.getGain());
        Debug.Log(food.getGain());
        defenseS.value += (float) defense.getGain();
        peopleS.value += (float) people.getGain();
        faithS.value += (float) faith.getGain();
        foodS.value += (float) food.getGain();
        stack.Clear();

        peopleT.text = "0";
        defenseT.text = "0";
        faithT.text = "0";
        foodT.text = "0";


    }

    public void People()
    {
        people.execute(peopleT, defenseT, faithT, foodT, people);
    }
    public void Defense()
    {
        defense.execute(peopleT, defenseT, faithT, foodT, defense);
    }
    public void Faith()
    {
        faith.execute(peopleT, defenseT, faithT, foodT, faith);
    }
    public void Food()
    {
        food.execute(peopleT, defenseT, faithT, foodT, food);
    }
    public void Sell()
    {
        sell.execute(peopleT, defenseT, faithT, foodT, sell);
    }
}
