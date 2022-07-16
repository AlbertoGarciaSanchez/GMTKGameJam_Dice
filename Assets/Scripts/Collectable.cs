using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string name;
    public void Collect()
    {
        GameManager.instance.AddToInventory(this);
    }
}
