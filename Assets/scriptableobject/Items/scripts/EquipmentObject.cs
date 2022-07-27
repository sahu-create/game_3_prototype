using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Equipment")]

public class EquipmentObject : ItemObject
{
    public float attackbonus;
    public float damage;
    public float defeancebonus;
    public void Awake()
    {
        type=ItemType.Equipment;
    }
}
