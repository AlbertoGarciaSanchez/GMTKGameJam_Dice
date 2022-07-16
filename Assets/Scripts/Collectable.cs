using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string name;

    public virtual void Collect()
    {
        GameManager.instance.AddToInventory(this);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if contains Interactable class and if it has not been already interacted.
        PlayerMovement player = col.gameObject.GetComponent<PlayerMovement>();
        if(player != null && player is PlayerMovement){
            this.Collect();
        }

        if(name == "Dice"){
            if(GameManager.instance.currentHearts >= GameManager.instance.maximumHearts){
                return;
            }

            //Lanzar evento
            EventManager.instance.OnHeartUpAction();
        }

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this);
    }
}
