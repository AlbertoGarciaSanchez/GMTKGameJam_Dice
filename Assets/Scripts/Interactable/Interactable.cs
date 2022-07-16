using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool alreadyInteracted = false;

    public virtual void OnInteract()
    {
        alreadyInteracted = true;
    }
}