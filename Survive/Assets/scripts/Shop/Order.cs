using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Order {

    public abstract void execute(Text text1, Text text2, Text text3, Text text4, Order order);

    public virtual void undo(Text text1, Text text2, Text text3, Text text4) { }

    public virtual double getGain() { return 0; }



}
