using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestRich : Chest
{
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        numberOfLoot = 3;

        lB.allItems = new Collectable[3] {cloverPrefab.GetComponent<Collectable>(), horseshowPrefab.GetComponent<Collectable>(), dicePrefab.GetComponent<Collectable>()};
        lB.probabilitiesPerItem = new double[3] { 10.0, 20.0, 35.0};
    }
}
