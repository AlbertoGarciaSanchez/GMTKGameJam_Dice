using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMedium : Chest
{
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();

        numberOfLoot = 2;

        lB.allItems = new Collectable[3] {cloverPrefab.GetComponent<Collectable>(), horseshowPrefab.GetComponent<Collectable>(), dicePrefab.GetComponent<Collectable>()};
        lB.probabilitiesPerItem = new double[3] { 20.0, 40.0, 15.0};
    }
}
