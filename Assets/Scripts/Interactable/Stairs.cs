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

        GameManager.instance.AddLevel();

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
