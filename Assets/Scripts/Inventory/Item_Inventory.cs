using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability item data")]
public class Item_Inventory : ScriptableObject
{
    // Start is called before the first frame update
    public string id;
    public string displayname;
    public GameObject prefab;
}
