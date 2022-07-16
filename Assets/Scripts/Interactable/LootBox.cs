using System.Collections;
using System.Collections.Generic;
using GamePX;
using UnityEngine;

public class LootBox : MonoBehaviour
{

    public Collectable[] allItems;

    public double[] probabilitiesPerItem;

    private ListUtil<Collectable> lootBox;
    // Start is called before the first frame update
    void Start()
    {
        lootBox = new ListUtil<Collectable>();
    }

    public Collectable ResolveLootBox()
    {
        Debug.Log("lootBox: " + lootBox);
        Debug.Log("allItems: " + allItems);
        Debug.Log("probabilitiesPerItem: " + probabilitiesPerItem);
        return lootBox.GetElement(allItems, probabilitiesPerItem);
    }
}
