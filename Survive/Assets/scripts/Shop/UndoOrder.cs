using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UndoOrder : Order {

    

    public override void execute(Text text1, Text text2, Text text3, Text text4, Order order)
    {


        List<Order> oldOrders = Stack.stack;

        if (oldOrders.Count > 0)
        {
            Order cOrder = oldOrders[oldOrders.Count - 1];
           
                cOrder.undo(text1, text2, text3, text4);
            
            
                
                
            
            oldOrders.RemoveAt(oldOrders.Count - 1);
        }
    }
}
