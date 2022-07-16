using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // Interactable Sprite indicator
    public GameObject interactableIndicator;

    // Interactable Key
    public KeyCode interactionKey = KeyCode.E;

    // Interactable flag to detect user's input
    private bool interactionKeyPressed = false;

    // List to track multiple interactable objects colliding simultaneously to the player.
    private List<Interactable> interactables = new List<Interactable>(){ };

    void Update()
    {
        interactionKeyPressed = Input.GetKeyDown(interactionKey);

        if(interactionKeyPressed){
            List<Interactable> objectsToBeRemoved = new List<Interactable>(){ };

            // Loop for detects interactable objects already interacted.
            foreach (Interactable objectInt in interactables)
            {
                objectInt.OnInteract();

                if(objectInt.alreadyInteracted){
                    objectsToBeRemoved.Add(objectInt);
                }
            }

            // Remove already interacted objects from list
            foreach (Interactable objectInt in objectsToBeRemoved)
            {
                interactables.Remove(objectInt);
            }

            // Update warning icon.
            checkInteractablesCollided();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check if contains Interactable class and if it has not been already interacted.
        Interactable interactable = col.gameObject.GetComponent<Interactable>();
        if(interactable != null && interactable is Interactable && !interactable.alreadyInteracted){
            interactables.Add(interactable);
        }
        
        // Update warning icon.
        checkInteractablesCollided();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Interactable interactable = col.gameObject.GetComponent<Interactable>();
        if(interactable != null && interactable is Interactable && !interactable.alreadyInteracted){
            interactables.Remove(interactable);
        }

        // Update warning icon.
        checkInteractablesCollided();
    }

    // Update warning icon.
    void checkInteractablesCollided(){
        if(interactables.Count <= 0){
            interactableIndicator.SetActive(false);
        }else{
            interactableIndicator.SetActive(true);
        }
    }
}
