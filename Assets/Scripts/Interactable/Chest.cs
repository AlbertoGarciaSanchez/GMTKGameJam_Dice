using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Sprite chestOpened;
    public Sprite chestClosed;

    public SpriteRenderer sr;

    void Start(){
        sr.sprite = chestClosed; 
    }

    public override void OnInteract()
    {
        // Update Interacted flag
        base.OnInteract();

        // Change sprite status of the chest to opened.
        sr.sprite = chestOpened; 

        // Perform whatever...
    }
}
