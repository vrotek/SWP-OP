﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodStat : Order
{
    
    private static double gain = 0;

    public override void execute(Text text1, Text text2, Text text3, Text text4, Order order)
    {
        if (AddText.score >= 10)
        {
            gain += 1;
            text4.text = gain.ToString();
            AddText.score -= 10;
            Debug.Log("execute food");
            Stack.stack.Add(order);
        }
    }

    public override void undo(Text text1, Text text2, Text text3, Text text4)
    {
        gain -= 1;
        text4.text = gain.ToString();
        AddText.score += 10;
    }

    public override double getGain()
    {
        double result = gain / 10;
        return result;
    }
}
