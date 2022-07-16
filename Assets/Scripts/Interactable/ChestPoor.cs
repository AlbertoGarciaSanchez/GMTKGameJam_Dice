using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPoor : Chest
{
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        lB.allItems = new Collectable[2] {cloverPrefab.GetComponent<Collectable>(), horseshowPrefab.GetComponent<Collectable>()};
        lB.probabilitiesPerItem = new double[2] { 50.0, 20.0};
    }
}
