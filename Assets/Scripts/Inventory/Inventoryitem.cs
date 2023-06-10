using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventoryitem : MonoBehaviour
{
    public Item_Inventory data { get; private set; }
    public int stacksize { get; private set; }

    public Inventoryitem(Item_Inventory source)
    {
        data = source;
        AddtoStack();
    }
    public void AddtoStack()
    {
        stacksize++;
    }
    public void RemovefromStack()
    {
        stacksize--;
    }
}
