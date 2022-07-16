using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : Interactable
{
    public override void OnInteract()
    {
        // Update Interacted flag
        base.OnInteract();

        int levels = 0;
        levels++;
        //TODO: level storage between scenes

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
