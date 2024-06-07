using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/MakeItem", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int itemIndex;
    public int ItemIndex { get { return itemIndex; } }

    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName; } }

    [SerializeField]
    private int price;
    public int Price { get { return price; } }

    [SerializeField]
    private GameObject weapon;
    public GameObject Weapon { get { return weapon; } }
}
