using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class ConsumableObject : ItemObject
{
    public int restorehealthvalue;
    public void Awake()
    {
        type = ItemType.Consumable;
    }
}
